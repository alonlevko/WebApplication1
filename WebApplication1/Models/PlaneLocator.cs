using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApplication1.Models
{
    public class PlaneLocator
    {
        public PlanePos GetPlanePosition(string ip, int port)
        {
            // the string we need to send to the simulator to get the values
            string logtitude = "get /position/longitude-deg" + Environment.NewLine;
            string latitude = "get /position/latitude-deg" + Environment.NewLine;
            string rudder = "get /controls/flight/rudder" + Environment.NewLine;
            string throttle = "get /controls/engines/current-engine/throttle" + Environment.NewLine;
            PlanePos result = new PlanePos();
            try
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
                TcpClient client = new TcpClient();
                client.Connect(ep);
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using(StreamReader reader = new StreamReader(stream))
                {
                    // read the values we need from the simulator
                    string answer;
                    writer.Write(Encoding.ASCII.GetBytes(logtitude));
                    // make sure the data gets to the server right now.
                    writer.Flush();
                    answer = reader.ReadLine();
                    result.longtitude = getNum(answer);
                    writer.Write(Encoding.ASCII.GetBytes(latitude));
                    // make sure the data gets to the server right now.
                    writer.Flush();
                    answer = reader.ReadLine();
                    result.lattitude = getNum(answer);
                    writer.Write(Encoding.ASCII.GetBytes(rudder));
                    writer.Flush();
                    answer = reader.ReadLine();
                    result.rudder = getNum(answer);
                    writer.Write(Encoding.ASCII.GetBytes(throttle));
                    writer.Flush();
                    answer = reader.ReadLine();
                    result.throttle = getNum(throttle);
                }
                // close the connection.
                client.Close();
            }
            catch (Exception)
            {
                result.lattitude = 0;
                result.longtitude = 0;
            }
            // return the plane position with the parameters
            return result;
        }
        // used to extract the number from the return string
        private double getNum(string str)
        {
            Regex regex = new Regex(@"-?\d+(?:\.\d+)?");
            Match match = regex.Match(str);
            if (match.Success)
            {
                return double.Parse(match.Value);
            }
            return 0;
        }
    }
}