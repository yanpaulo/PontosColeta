using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PontosColeta.WebApp.Models;

namespace PontosColeta.WebApp.ApiControllers
{
    public class PlacesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Places
        public IEnumerable<Place> GetPlaces([FromUri]string wkt = null, [FromUri]string search = null)
        {
            search = !string.IsNullOrEmpty(search) ? search : null;
            var geography = !string.IsNullOrEmpty(wkt) ? DbGeography.FromText(wkt) : null;
            return db.Places
                .Where(p => search == null || p.Name.Contains(search))
                .ToList()
                .Select(p => MapPlace(p, geography))
                .ToList();
        }

        // GET: api/Places/5
        [ResponseType(typeof(Place))]
        public IHttpActionResult GetPlace(int id)
        {
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return NotFound();
            }

            return Ok(MapPlace(place));
        }

        // PUT: api/Places/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlace(int id, Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != place.Id)
            {
                return BadRequest();
            }

            db.Entry(place).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Places
        [ResponseType(typeof(Place))]
        public IHttpActionResult PostPlace(Place place)
        {
            ModelState.Remove(nameof(Place.Location));
            ModelState.Remove($"place.{nameof(Place.Location)}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var location = DbGeography.FromText(place.LocationWKT);
            place.Location = location;
            place.WorkingDays = place.WorkingDays.Where(day => day.IsEnabled).ToList();

            db.Places.Add(place);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = place.Id }, place);
        }

        // DELETE: api/Places/5
        [ResponseType(typeof(Place))]
        public IHttpActionResult DeletePlace(int id)
        {
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return NotFound();
            }

            db.Places.Remove(place);
            db.SaveChanges();

            return Ok(place);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private Place MapPlace(Place p, DbGeography geography = null)
        {
            p.LocationWKT = p.Location.AsText();
            p.WorkingDays = Enumerable.Range(0, 7)
                .Select(n => p.WorkingDays.SingleOrDefault(day => (int)day.DayOfWeek == n) ?? new PlaceWorkingDay { DayOfWeek = (DayOfWeek)n })
                .ToList();
            if (geography != null)
            {
                p.Distance = p.Location.Distance(geography);
            }

            return p;
        }

        private bool PlaceExists(int id)
        {
            return db.Places.Count(e => e.Id == id) > 0;
        }
    }
}