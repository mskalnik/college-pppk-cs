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
            return View(repo.GetTravelOrders());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.orders = repo.GetTravelOrders();
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
                ViewBag.orders = repo.GetTravelOrders();
                return View(t);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
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
                ViewBag.orders = repo.GetTravelOrders();
                return View(t);
            }
        }
    }
}