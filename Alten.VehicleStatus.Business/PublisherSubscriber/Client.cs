using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alten.VehicleStatus.Business.PublisherSubscriber
{
   public class ClientListner
    {
        static Subscriber subscriber;
        public ClientListner(byte[] ipAddress, int portNumber)
        {
            if(subscriber==null)
             subscriber = new Subscriber(ipAddress, portNumber);
        }
        public void Listen()
        {           
            Task task = Task.Factory.StartNew(() => subscriber.Listen());
            Task.WaitAll(task);

        }
    }
}
