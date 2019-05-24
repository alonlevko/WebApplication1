using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace WebApplication1.Models
{
    [Serializable]
    public class PlanePos
    {
        public PlanePos() { }
        [XmlAttribute]
        public double lattitude;
        [XmlAttribute]
        public double longtitude;
    }
}