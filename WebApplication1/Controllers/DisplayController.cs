﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
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
            IPAddress address;
            // check if ip is actually an ip address
            if (IPAddress.TryParse(ip, out address)) {
                // return the regular diplay
                ViewBag.ip = ip;
                ViewBag.port = port;
                return View("~/Views/Display/Display.cshtml");
            } else // we need to load a file
            {
                // it is a filename
                string fileName = ip;
                // create a serializer
                XmlSerializer serializer = new XmlSerializer(typeof(List<PlanePos>));
                var dir = Server.MapPath("~/");
                var file = Path.Combine(dir, fileName + ".xml");
                // read the serialized xml to a list of positions
                StreamReader reader = new StreamReader(file);
                List<PlanePos> positions = (List<PlanePos>)serializer.Deserialize(reader);
                // pass the positions to the view
                ViewBag.positions = positions;
                ViewBag.perSecond = port;
                ViewBag.length = positions.Count;
                return View("~/Views/Display/Animation.cshtml");
            }
            
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
            // return a json that is the plane location
            PlaneLocator loc = new PlaneLocator();
            PlanePos p = loc.GetPlanePosition(ip, port);
            return Json(p, JsonRequestBehavior.AllowGet);
        }
    }
}