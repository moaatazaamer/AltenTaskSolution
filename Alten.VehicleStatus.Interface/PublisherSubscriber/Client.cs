using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alten.VehicleStatus.Interface.PublisherSubscriber
{
   public class ClientListner
    {
        Subscriber subscriber;
        public ClientListner(byte[] ipAddress, int portNumber)
        {
             subscriber = new Subscriber(ipAddress, portNumber);
        }
        public string CheckPing()
        {           
            Task task = Task.Factory.StartNew(() => subscriber.Listen());
            return subscriber.message;       
        }
    }
}
