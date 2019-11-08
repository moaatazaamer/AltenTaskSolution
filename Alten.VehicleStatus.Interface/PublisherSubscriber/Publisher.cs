using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Alten.VehicleStatus.Interface.PublisherSubscriber
{
   public class Publisher
    {
        private Socket sender;
        byte[] localhost;
        int port;

        //Push to port
        public Publisher(byte[] localhost, int port)
        {
            this.localhost = localhost;
            this.port = port;
            IPAddress address = new IPAddress(localhost);
            IPEndPoint endPoint = new IPEndPoint(address, port);
            sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (!sender.Connected) 
            sender.Connect(endPoint);
        }

        //Send response to receiver
        public void Send()
        {
              
            try
            {
                Random r = new Random();
                string msg = r.Next(0, 3) % 2 == 0 ? "Connected" : "Disonnected";
                byte[] statusToSend = Encoding.ASCII.GetBytes(msg);                  
                sender.SendBufferSize = 256;
                sender.Send(statusToSend);                
               
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                sender.Close();
            }
            finally
            {
               
            }
        }
    }
}
