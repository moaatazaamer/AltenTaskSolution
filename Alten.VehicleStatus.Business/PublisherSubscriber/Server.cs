using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alten.VehicleStatus.Business.PublisherSubscriber
{
    public class ServerPublisher
    {
        Publisher publisher;
        public ServerPublisher(byte[] ipAddress, int portNumber)
        {
            publisher = new Publisher(ipAddress, portNumber);
        }
        public string SendPing()
        {

            Task senderTask = Task.Factory.StartNew(() => publisher.Send());
            Task.WaitAll(senderTask);
            return publisher.message;
        }
    }
}
