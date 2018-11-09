using I1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace I1.Controllers
{
    public class DriverController : Controller
    {
        IRepo repo = RepoFactory.GetRepo();

        public ActionResult All()
        {
            return View(repo.GetDrivers());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.drivers = repo.GetDrivers();
            return View(repo.GetDriver(id));
        }

        [HttpPost]
        public ActionResult Edit(Driver d)
        {
            if (ModelState.IsValid)
            {
                repo.EditDriver(d);
                return RedirectToAction("All");
            }
            else
            {
                ViewBag.gradovi = repo.GetDrivers();
                return View(d);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Driver d)
        {
            if (ModelState.IsValid)
            {
                repo.AddDriver(d);
                return RedirectToAction("All");
            }
            else
            {
                ViewBag.gradovi = repo.GetDrivers();
                return View(d);
            }
        }
    }
}