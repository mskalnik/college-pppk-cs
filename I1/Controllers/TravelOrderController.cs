using I1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace I1.Controllers
{
    public class TravelOrderController : Controller
    {
        IRepo repo = RepoFactory.GetRepo();

        public ActionResult All()
        {
            ViewBag.types = repo.GetTravelOrderTypes();
            ViewBag.drivers = repo.GetDrivers();
            ViewBag.cities = repo.GetCities();
            ViewBag.car = repo.GetCars();
            return View(repo.GetTravelOrders());
        }

        public ActionResult Open()
        {
            ViewBag.types = repo.GetTravelOrderTypes();
            ViewBag.drivers = repo.GetDrivers();
            ViewBag.cities = repo.GetCities();
            ViewBag.car = repo.GetCars();
            return View(repo.GetTravelOrders(1));
        }

        public ActionResult Closed()
        {
            ViewBag.types = repo.GetTravelOrderTypes();
            ViewBag.drivers = repo.GetDrivers();
            ViewBag.cities = repo.GetCities();
            ViewBag.car = repo.GetCars();
            return View(repo.GetTravelOrders(2));
        }

        public ActionResult Future()
        {
            ViewBag.types = repo.GetTravelOrderTypes();
            ViewBag.drivers = repo.GetDrivers();
            ViewBag.cities = repo.GetCities();
            ViewBag.car = repo.GetCars();
            return View(repo.GetTravelOrders(3));
        }

        public ActionResult Filtered()
        {
            ViewBag.types = repo.GetTravelOrderTypes();
            ViewBag.drivers = repo.GetDrivers();
            ViewBag.cities = repo.GetCities();
            ViewBag.car = repo.GetCars();
            return View(repo.GetTravelOrders(4));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.types = repo.GetTravelOrderTypes();
            ViewBag.drivers = repo.GetDrivers();
            ViewBag.cities = repo.GetCities();
            ViewBag.car = repo.GetCars();
            return View(repo.GetTravelOrder(id));
        }

        [HttpPost]
        public ActionResult Edit(TravelOrder t)
        {
            if (ModelState.IsValid)
            {
                repo.EditTravelOrder(t);
                return RedirectToAction("All");
            }
            else
            {
                ViewBag.types = repo.GetTravelOrderTypes();
                ViewBag.drivers = repo.GetDrivers();
                ViewBag.cities = repo.GetCities();
                ViewBag.car = repo.GetCars();
                return View(t);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.types = repo.GetTravelOrderTypes();
            ViewBag.drivers = repo.GetDrivers();
            ViewBag.cities = repo.GetCities();
            ViewBag.car = repo.GetCars();
            return View();
        }

        [HttpPost]
        public ActionResult Add(TravelOrder t)
        {
            if (ModelState.IsValid)
            {
                repo.AddTravelOrder(t);
                return RedirectToAction("All");
            }
            else
            {
                ViewBag.types = repo.GetTravelOrderTypes();
                ViewBag.drivers = repo.GetDrivers();
                ViewBag.cities = repo.GetCities();
                ViewBag.car = repo.GetCars();
                return View(t);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            repo.DeleteTravelOrder(id);
            return RedirectToAction("All");
        }
    }
}