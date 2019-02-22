using I1.Dal;
using I1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace I1.Controllers
{
    public class RouteController : Controller
    {
        DaabRepo repo = new DaabRepo();

        public ActionResult All()
        {
            return View(repo.GetRoutes());
        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    return View(repo.GetRoutes(id));
        //}

        //[HttpPost]
        //public ActionResult Edit(Driver d)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repo.EditDriver(d);
        //        return RedirectToAction("All");
        //    }
        //    else
        //    {
        //        ViewBag.gradovi = repo.GetDrivers();
        //        return View(d);
        //    }
        //}

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Route r)
        {
            if (ModelState.IsValid)
            {
                repo.AddRoute(r);
                return RedirectToAction("All");
            }
            else
            {
                ViewBag.routes = repo.GetRoutes();
                return View(r);
            }
        }

        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    repo.DeleteDriver(id);
        //    return RedirectToAction("All");
        //}
    }
}