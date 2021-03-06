﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PontosColeta.UserApp.Services
{
    public class WebService
    {
        private readonly HttpClient client = new HttpClient
        {
            //BaseAddress = new Uri("http://localhost:5049/api/")
            BaseAddress = new Uri("http://coleta.yanscorp.com/api/")
        };

        public async Task<List<Place>> GetPlaces(string wkt, string search)
        {
            var response = await client.GetAsync($"Places?wkt={wkt}&search={search}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Erro {response.StatusCode}: {content}");
            }
            var places = JsonConvert.DeserializeObject<List<Place>>(content);
            return places;
        }
    }
}
