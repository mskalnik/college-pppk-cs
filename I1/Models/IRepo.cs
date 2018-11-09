using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace I1.Models
{
    public interface IRepo
    {
        //Driver
        List<Driver> GetDrivers();
        Driver GetDriver(int id);
        void AddDriver(Driver driver);
        void EditDriver(Driver driver);
        void DeleteDriver(int id);

        //Car
        List<Car> GetCars();
        Car GetCar(int id);
        void AddCar(Car car);
        void EditCar(Car car);
        void DeleteCar(int id);
    }
}