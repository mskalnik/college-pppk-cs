using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace I1.Models
{
    public class TravelOrder
    {
        public int IDTravelOrder { get; set; }
        public int Distance { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public int TravelOrderTypeID { get; set; }
        public int DriverID { get; set; }
        public int StartCityID { get; set; }
        public int FinishCityID { get; set; }
        public int CarID { get; set; }
    }
}