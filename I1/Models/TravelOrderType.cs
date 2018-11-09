using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace I1.Models
{
    public class TravelOrderType
    {
        public int IDTravelOrderType { get; set; }
        public string Type { get; set; }

        public TravelOrderType(string type)
        {
            Type = type;
        }
    }
}