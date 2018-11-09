using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace I1.Controllers
{
    public class CarController : Controller
    {
        // GET: Vehicle
        public ActionResult Index()
        {
            return View();
        }
    }
}