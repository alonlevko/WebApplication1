﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace WebApplication1.Models
{
    public class PlaneLocator
    {
        PlanePos GetPlanePosition(string ip, int port)
        {
            string logtitude = "get /position/longitude-deg" + Environment.NewLine;
            string latitude = "get /position/latitude-deg" + Environment.NewLine;
            PlanePos result = new PlanePos();
            try
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
                TcpClient client = new TcpClient();
                client.Connect(ep);
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using(BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write(logtitude);
                    // make sure the data gets to the server right now.
                    writer.Flush();
                    result.longtitude = reader.ReadDouble();
                    writer.Write(latitude);
                    // make sure the data gets to the server right now.
                    writer.Flush();
                    result.lattitude = reader.ReadDouble();
                }
                // close the connection.
                client.Close();
            }
            catch (Exception)
            {
                result.lattitude = 0;
                result.longtitude = 0;
            }
            return result;
        }
    }
}