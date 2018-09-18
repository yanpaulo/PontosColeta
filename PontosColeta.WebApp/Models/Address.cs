using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PontosColeta.WebApp.Models
{
    public class Address
    {
        [Required]
        public string Adress1 { get; set; }

        public string Adress2 { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

    }
}