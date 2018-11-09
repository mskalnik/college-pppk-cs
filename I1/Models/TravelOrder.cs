using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace I1.Models
{
    public class TravelOrder
    {
        public int IDTravelOrder { get; set; }
        public int Distance { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TravelOrderTypeID { get; set; }
        public int DriverID { get; set; }
        public int StartCityID { get; set; }
        public int FinishCityID { get; set; }

        public TravelOrder(int distance, DateTime startDate, DateTime endDate, int travelOrderTypeID, int driverID, int startCityID, int finishCityID)
        {
            Distance = distance;
            StartDate = startDate;
            EndDate = endDate;
            TravelOrderTypeID = travelOrderTypeID;
            DriverID = driverID;
            StartCityID = startCityID;
            FinishCityID = finishCityID;
        }
    }
}