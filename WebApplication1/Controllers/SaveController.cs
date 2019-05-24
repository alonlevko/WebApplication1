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
        public ActionResult Saver(string ip, int port, int perSec, int seconds, string fileName)
        {
            RandomLocator locator = new RandomLocator();
            LinkedList<PlanePos> list = new LinkedList<PlanePos>();
            for(int i = 0; i < perSec * seconds; i++ )
            {
                PlanePos plane = locator.GetLocation();
                list.AddLast(plane);
                Thread.Sleep(1000/perSec);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(LinkedList<PlanePos>), new Type[] { typeof(PlanePos) });
            //TextWriter writer = new StreamWriter(fileName);
            string str = fileName + ".xml";
            FileStream stream = new FileStream(str, FileMode.Create, FileAccess.Write, FileShare.None);
            serializer.Serialize(stream, list);
            return View("~/Views/Saver.cshtml");
        }

    }
}