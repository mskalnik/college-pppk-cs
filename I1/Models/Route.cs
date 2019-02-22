using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace I1.Models
{
    public class Route
    {
        public int IDRoute { get; set; }
        public double StartCoordinate { get; set; }
        public double EndCoordinate { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public double Distance { get; set; }
        public double FuelUsed { get; set; }
        public int TravelOrderID { get; set; }
    }
}