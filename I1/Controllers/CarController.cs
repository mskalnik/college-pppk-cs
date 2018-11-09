using I1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace I1.Controllers
{
    public class CarController : Controller
    {
        IRepo repo = new Repo();

        // GET: Car
        public ActionResult All()
        {
            ViewBag.brands = repo.GetCarBrands();
            ViewBag.types = repo.GetCarTypes();
            return View(repo.GetCars());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.brands = repo.GetCarBrands();
            ViewBag.types = repo.GetCarTypes();
            return View(repo.GetCar(id));
        }

        [HttpPost]
        public ActionResult Edit(Car c)
        {
            if (ModelState.IsValid)
            {
                repo.EditCar(c);
                return RedirectToAction("All");
            }
            else
            {
                ViewBag.cars = repo.GetCars();
                return View(c);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.brands = repo.GetCarBrands();
            ViewBag.types = repo.GetCarTypes();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Car c)
        {
            if (ModelState.IsValid)
            {
                repo.AddCar(c);
                return RedirectToAction("All");
            }
            else
            {
                ViewBag.brands = repo.GetCarBrands();
                ViewBag.types = repo.GetCarTypes();
                return View(c);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            repo.DeleteCar(id);
            return RedirectToAction("All");
        }
    }
}