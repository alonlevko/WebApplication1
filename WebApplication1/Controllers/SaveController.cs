using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class SaveController : Controller
    {
        // GET: Save
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Saver(string ip, int port, int perSec, int seconds, string fileName)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Location(string ip, int port)
        {

        }
    }
}