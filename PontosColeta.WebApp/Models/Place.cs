using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace PontosColeta.WebApp.Models
{
    public class Place
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DbGeography Location { get; set; }

        public Address Address { get; set; }

        public virtual List<PlaceWorkingDay> WorkingDays { get; set; }


    }
}