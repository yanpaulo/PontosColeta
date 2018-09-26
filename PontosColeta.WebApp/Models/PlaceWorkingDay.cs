using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PontosColeta.WebApp.Models
{
    public class PlaceWorkingDay
    {
        public int Id { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        [NotMapped]
        public bool IsEnabled => Id != 0;
    }
}