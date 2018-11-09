using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace I1.Models
{
    public class Repo : IRepo
    {      
		private string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public void AddCar(Car car)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "AddCar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCar", car.IDCar);
                    cmd.Parameters.AddWithValue("@Registration", car.Registration);
                    cmd.Parameters.AddWithValue("@InitialKm", car.InitialKm);
                    cmd.Parameters.AddWithValue("@YearOfProduction", car.YearOfProduction);
                    cmd.Parameters.AddWithValue("@CarTypeID", car.CarTypeID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddDriver(Driver driver)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO Driver VALUES('{driver.FirstName}', '{driver.LastName}', '{driver.PhoneNumber}', '{driver.DriversLicenceNumber}')";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddTravelOrder(TravelOrder to)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO TravelOrder VALUES('{to.Distance}', '{to.StartDate}', '{to.EndDate}', '{to.TravelOrderTypeID}', '{to.DriverID}', '{to.StartCityID}', '{to.FinishCityID}', '{to.CarID}')";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCar(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteDriver(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTravelOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void EditCar(Car car)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "EditCar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCar", car.IDCar);
                    cmd.Parameters.AddWithValue("@Registration", car.Registration);
                    cmd.Parameters.AddWithValue("@InitialKm", car.InitialKm);
                    cmd.Parameters.AddWithValue("@YearOfProduction", car.YearOfProduction);
                    cmd.Parameters.AddWithValue("@CarTypeID", car.CarTypeID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditDriver(Driver driver)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"UPDATE Driver SET FirstName = '{driver.FirstName}', LastName = '{driver.LastName}', PhoneNumber = '{driver.PhoneNumber}', DriversLicenceNumber = '{driver.DriversLicenceNumber}' WHERE IDDriver = '{driver.IDDriver}'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditTravelOrder(TravelOrder to)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"UPDATE TravelOrder SET Distance = '{to.Distance}', StartDate = '{to.StartDate}', EndDate = '{to.EndDate}', TravelOrderTypeID = '{to.TravelOrderTypeID}', DriverID = '{to.DriverID}', StartCityID = '{to.StartCityID}', FinishCityID = '{to.FinishCityID}', CarID = '{to.CarID}' WHERE IDTravelOrder = '{to.IDTravelOrder}'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Car GetCar(int id)
        {
            return GetCars().Single(c => c.IDCar == id);
        }

        public List<CarBrand> GetCarBrands()
        {
            List<CarBrand> carBrandList = new List<CarBrand>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "GetCarBrands";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                carBrandList.Add(new CarBrand
                                {
                                    IDCarBrand = (int)r["IDCarBrand"],
                                    Name = r["Name"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return carBrandList;
        }

        public List<Car> GetCars()
        {
            List<Car> carList = new List<Car>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "GetCars";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                carList.Add(new Car
                                {
                                    IDCar = (int)r["IDCar"],
                                    Registration = r["Registration"].ToString(),
                                    InitialKm = (int)r["InitialKm"],
                                    YearOfProduction = (int)r["YearOfProduction"],
                                    CarTypeID = (int)r["CarTypeID"]
                                });
                            }
                        }
                    }
                }
            }
            return carList;
        }

        public List<CarType> GetCarTypes()
        {
            List<CarType> carTypes = new List<CarType>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "GetCarTypes";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                carTypes.Add(new CarType
                                {
                                    IDCarType = (int)r["IDCarType"],
                                    Name = r["Name"].ToString(),
                                    CarBrandID = (int)r["CarBrandID"]
                                });
                            }
                        }
                    }
                }
            }
            return carTypes;
        }

        public List<City> GetCities()
        {
            List<City> cities = new List<City>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "GetCities";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                cities.Add(new City
                                {
                                    IDCity = (int)r["IDCity"],
                                    Name = r["Name"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return cities;
        }

        public Driver GetDriver(int id)
        {
            return GetDrivers().Single(d => d.IDDriver == id);
        }

        public List<Driver> GetDrivers()
        {
            List<Driver> driversList = new List<Driver>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Driver";
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                driversList.Add(new Driver
                                {
                                    IDDriver                = (int)r["IDDriver"],
                                    FirstName               = r["FirstName"].ToString(),
                                    LastName                = r["LastName"].ToString(),
                                    PhoneNumber             = r["PhoneNumber"].ToString(),
                                    DriversLicenceNumber    = r["DriversLicenceNumber"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return driversList;
        }

        public List<Fuel> GetFuels()
        {
            List<Fuel> fuels = new List<Fuel>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "GetFuels";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                fuels.Add(new Fuel
                                {
                                    IDFuel = (int)r["IDFuel"],
                                    Name = r["Name"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return fuels;
        }

        public TravelOrder GetTravelOrder(int id)
        {
            return GetTravelOrders().Single(t => t.IDTravelOrder == id);
        }

        public List<TravelOrder> GetTravelOrders()
        {
            List<TravelOrder> travelOrders = new List<TravelOrder>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM TravelOrder";
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                travelOrders.Add(new TravelOrder
                                {
                                    IDTravelOrder = (int)r["IDTravelOrder"],
                                    Distance = (int)r["Distance"],
                                    StartDate = (DateTime)r["StartDate"],
                                    EndDate = (DateTime)r["EndDate"],
                                    TravelOrderTypeID = (int)r["TravelOrderTypeID"],
                                    DriverID = (int)r["DriverID"],
                                    StartCityID = (int)r["StartCityID"],
                                    FinishCityID = (int)r["FinishCityID"],
                                    CarID = (int)r["CarID"],
                                });
                            }
                        }
                    }
                }
            }
            return travelOrders;
        }

        public List<TravelOrderType> GetTravelOrderTypes()
        {
            List<TravelOrderType> travelOrderTypes = new List<TravelOrderType>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "GetTravelOrderTypes";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                travelOrderTypes.Add(new TravelOrderType
                                {
                                    IDTravelOrderType = (int)r["IDTravelOrderType"],
                                    Type = r["Type"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return travelOrderTypes;
        }
    }
}