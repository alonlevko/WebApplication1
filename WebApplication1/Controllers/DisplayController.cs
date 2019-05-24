using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class DisplayController : Controller
    {
        // GET: Display
        public ActionResult Index(string ip, int port)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Display(string ip, int port)
        {
            ViewBag.ip = ip;
            ViewBag.port = port;
            return View();
        }

        [HttpGet]
        public ActionResult DisplayRouth(string ip, int port, int seconds)
        {
            ViewBag.ip = ip;
            ViewBag.port = port;
            ViewBag.seconds = seconds;
            return View("~/Views/Display/DisplayRouth.cshtml");
        }

        [HttpGet]
        public ActionResult Location(string ip, int port)
        {
            RandomLocator loc = new RandomLocator();
            PlanePos p = loc.GetLocation();
            return Json(p, JsonRequestBehavior.AllowGet);
        }
    }
}