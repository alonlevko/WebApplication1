using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Threading;

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
        public ActionResult Saver(string ip, int port, int perSeconds, int seconds, string fileName)
        {
            // run the saving of the values in a new thread so the user won't wait for response
            new Thread(() =>
            {
                // create a locator finding object
                PlaneLocator locator = new PlaneLocator();
                List<PlanePos> list = new List<PlanePos>();
                // get the valued as requested in the url
                for (int i = 0; i < perSeconds * seconds; i++)
                {
                    PlanePos plane = locator.GetPlanePosition(ip, port);
                    list.Add(plane);
                    Thread.Sleep(1000 / perSeconds);
                }
                // create a serializer
                XmlSerializer serializer = new XmlSerializer(typeof(List<PlanePos>), new Type[] { typeof(PlanePos) });
                // save the file to the location of the code
                string str = fileName + ".xml";
                var dir = Server.MapPath("~/");
                var file = Path.Combine(dir, fileName + ".xml");
                FileStream stream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None);
                serializer.Serialize(stream, list);
            }).Start();
            // send the values to the view
            ViewBag.seconds = seconds;
            ViewBag.ip = ip;
            ViewBag.port = port;
            ViewBag.perseconds = perSeconds;
            // show the view of the location of the plane
            return View("~/Views/Saver.cshtml");
        }

    }
}