using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace I1.Models
{
    public class Driver
    {
        public int IDDriver { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string DriversLicenceNumber { get; set; }

        public Driver(string firstName, string lastName, string phoneNumber, string driversLicenceNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            DriversLicenceNumber = driversLicenceNumber;
        }
    }
}