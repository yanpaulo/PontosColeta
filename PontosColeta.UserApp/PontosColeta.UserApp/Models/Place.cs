using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PontosColeta.UserApp
{
    public class Place
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public Address Address { get; set; }

        public List<PlaceWorkingDay> WorkingDays { get; set; }

        public double? Distance { get; set; }

    }
}