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

        public void AddDriver(Driver driver)
        {
            throw new NotImplementedException();
        }

        public void DeleteDriver(int id)
        {
            throw new NotImplementedException();
        }

        public void EditDriver(Driver driver)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"update Driver set FirstName = '{driver.FirstName}', LastName = '{driver.LastName}', PhoneNumber = '{driver.PhoneNumber}', DriversLicenceNumber = '{driver.DriversLicenceNumber}' where IDDriver = '{driver.IDDriver}'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
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
                    cmd.CommandText = "select * from Driver";
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