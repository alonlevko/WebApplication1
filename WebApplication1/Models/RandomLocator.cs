using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RandomLocator
    {
        // used only for testing
        public PlanePos GetLocation()
        {
            PlanePos plane = new PlanePos();
            Random rnd = new Random();
            plane.lattitude = rnd.NextDouble() * 90;
            plane.longtitude = rnd.NextDouble() * 180;
            return plane;
        }
    }
}