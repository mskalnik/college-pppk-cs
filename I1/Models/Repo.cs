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

        public void DeleteCar(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteDriver(int id)
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

        public Car GetCar(int id)
        {
            return GetCars().Single(c => c.IDCar == id);
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
                    cmd.CommandType = CommandType.Text;

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
    }
}