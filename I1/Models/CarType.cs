using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace I1.Models
{
    public class CarType
    {
        public int IDCarType { get; set; }
        public string Name { get; set; }
        public int CarBrandID { get; set; }

        public CarType(string name, int carBrandID)
        {
            Name = name;
            CarBrandID = carBrandID;
        }
    }
}