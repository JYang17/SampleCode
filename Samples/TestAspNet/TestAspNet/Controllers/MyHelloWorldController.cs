using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestAspNet.Controllers
{
    public class MyHelloWorldController : Controller
    {
        // GET: MyHelloWorld
        public ActionResult Index()
        {
            ViewBag.Title = "Set ViewBag in Controller";
            return View();
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }
    }
}