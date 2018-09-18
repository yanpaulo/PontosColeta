﻿using System;
using System.Collections.Generic;
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
    }
}