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
    }
}