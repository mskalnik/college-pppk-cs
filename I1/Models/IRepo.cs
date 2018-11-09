using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace I1.Models
{
    public interface IRepo
    {
        List<Driver> GetDrivers();
        Driver GetDriver(int id);
        void AddDriver(Driver driver);
        void EditDriver(Driver driver);
        void DeleteDriver(int id);
    }
}