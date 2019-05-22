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
            return View();
        }

        [HttpGet]
        public ActionResult DisplayRouth(string ip, int port, int seconds)
        {
            return View();
        }
    }
}