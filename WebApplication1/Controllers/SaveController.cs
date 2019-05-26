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
            new Thread(() =>
            {
                PlaneLocator locator = new PlaneLocator();
                List<PlanePos> list = new List<PlanePos>();
                for (int i = 0; i < perSeconds * seconds; i++)
                {
                    PlanePos plane = locator.GetPlanePosition(ip, port);
                    list.Add(plane);
                    Thread.Sleep(1000 / perSeconds);
                }
                XmlSerializer serializer = new XmlSerializer(typeof(List<PlanePos>), new Type[] { typeof(PlanePos) });
                //TextWriter writer = new StreamWriter(fileName);
                string str = fileName + ".xml";
                var dir = Server.MapPath("~/");
                var file = Path.Combine(dir, fileName + ".xml");
                FileStream stream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None);
                serializer.Serialize(stream, list);
            }).Start();
            ViewBag.seconds = seconds;
            ViewBag.ip = ip;
            ViewBag.port = port;
            ViewBag.perseconds = perSeconds;
            return View("~/Views/Saver.cshtml");
        }

    }
}