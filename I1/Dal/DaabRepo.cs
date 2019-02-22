using I1.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace I1.Dal
{
    public class DaabRepo
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static readonly SqlDatabase db = new SqlDatabase(cs);

        private readonly string XML_PATH = System.Web.Hosting.HostingEnvironment.MapPath("~/xml.xml");

        /************************* CRUD *************************/
        public void AddRoute(Route route)
        {
            db.ExecuteNonQuery("AddRoute", route.StartCoordinate, route.EndCoordinate, route.StartDate, 
                                route.EndDate, route.Distance, route.FuelUsed, route.TravelOrderID);
        }

        public List<Route> GetRoutes()
        {
            List<Route> routes = new List<Route>();
            using (IDataReader dr = db.ExecuteReader("GetRoutes"))
            {
                while (dr.Read())
                {
                    routes.Add(new Route
                    {
                        IDRoute         = (int)dr["IDRoute"],
                        StartCoordinate = (double)dr["StartCoordinate"],
                        EndCoordinate   = (double)dr["EndCoordinate"],
                        StartDate       = (DateTime)dr["StartDate"],
                        EndDate         = (DateTime)dr["EndDate"],
                        Distance        = (double)dr["Distance"],
                        FuelUsed        = (double)dr["FuelUsed"],
                        TravelOrderID   = (int)dr["TravelOrderID"]
                    });
                }
            }

            return routes;
        }

        public List<Route> GetRoutes(int idTravelOrder)
        {
            List<Route> routes = new List<Route>();
            using (IDataReader dr = db.ExecuteReader("GetRoutesFor", new Object[] { idTravelOrder }))
            {
                while (dr.Read())
                {
                    routes.Add(new Route
                    {
                        IDRoute         = (int)dr["IDRoute"],
                        StartCoordinate = (double)dr["StartCoordinate"],
                        EndCoordinate   = (double)dr["EndCoordinate"],
                        StartDate       = (DateTime)dr["StartDate"],
                        EndDate         = (DateTime)dr["EndDate"],
                        Distance        = (double)dr["Distance"],
                        FuelUsed        = (double)dr["FuelUsed"],
                        TravelOrderID   = (int)dr["TravelOrderID"]
                    });
                }
            }
            return routes;
        }
        public void UpdateRoute(Route route)
        {
            db.ExecuteNonQuery("UpdateRoute", route.IDRoute, route.StartCoordinate, route.EndCoordinate, route.StartDate,
                                route.EndDate, route.Distance, route.FuelUsed, route.TravelOrderID);
        }

        public void DeleteRoute(int idRoute)
        {
            db.ExecuteNonQuery("DeleteRoute", idRoute);
        }

        /************************* XML *************************/
        public void CreateXML()
        {
            SqlConnection con = new SqlConnection(cs);
            DataSet ds = new DataSet("Routes");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Route", con);

            sda.Fill(ds);
            ds.Tables[0].TableName = "Routes";
            ds.WriteXml(XML_PATH, XmlWriteMode.WriteSchema);

            con.Close();
        }

        public List<Route> LoadXML()
        {
            List<Route> routes = new List<Route>();
            DataSet ds = new DataSet();

            ds.ReadXml(XML_PATH);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                routes.Add(new Route
                {
                    IDRoute         = int.Parse(row["IDRoute"].ToString()),
                    StartCoordinate = double.Parse(row["StartCoordinate"].ToString()),
                    EndCoordinate   = double.Parse(row["EndCoordinate"].ToString()),
                    StartDate       = (DateTime)row["StartDate"],
                    EndDate         = (DateTime)row["EndDate"],
                    Distance        = double.Parse(row["Distance"].ToString()),
                    FuelUsed        = double.Parse(row["FuelUsed"].ToString()),
                    TravelOrderID   = int.Parse(row["TravelOrderID"].ToString())
                });
            }
            return routes;
        }
    }
}