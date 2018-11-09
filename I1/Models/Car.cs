using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace I1.Models
{
    public class Car
    {
        public int IDCar { get; set; }
        public string Registration { get; set; }
        public int InitialKm { get; set; }
        public int YearOfProduction { get; set; }
        public int CarTypeID { get; set; }
    }
}