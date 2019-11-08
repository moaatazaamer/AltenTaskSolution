using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Alten.VehicleStatus.Interface.PublisherSubscriber
{
    public class Subscriber
    {
        private Socket listener;
        byte[] localhost;
        int port;
        public string message = "Init";
        //listen to port
        public Subscriber(byte[] localhost, int port)
        {
            this.localhost = localhost;
            this.port = port;
            IPAddress address = new IPAddress(localhost);
            IPEndPoint endPoint = new IPEndPoint(address, port);
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);            
            listener.Bind(endPoint);
            listener.Listen(3);
        }

        //receive response from sender
        public void Listen()
        {
            
            byte[] buffer;
            int count;
            string response = String.Empty;
            try
            {
                
                while (true)
                {
                    buffer = new byte[256];
                    Socket receiver = listener.Accept();
                    while (true)
                    {
                        count = receiver.Receive(buffer);
                        string message = "Status: " + Encoding.ASCII.GetString(buffer,0, count);                        
                    }
                    
                }
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                // Exception handling
            }
        }
    }
}
