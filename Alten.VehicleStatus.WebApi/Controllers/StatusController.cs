using Alten.VehicleStatus.Business.PublisherSubscriber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Alten.VehicleStatus.WebApi.Controllers
{

    public class StatusController : ApiController
    {
       static ClientListner client;
       static ServerPublisher serverPublisher;
        byte[] ipAddress = new byte[] { 127, 0, 0, 1 };
        int portNumber = 8181;

        [HttpPost]
        public HttpResponseMessage Listen()
        {
            //initiate client listener
          
            try
            {
                if (client == null)
                {
                    client = new ClientListner(ipAddress, portNumber);
                    client.Listen();
                }
              
               return Request.CreateResponse(HttpStatusCode.OK, "up");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }

        }
        [HttpGet]
        public HttpResponseMessage PingStatus()
        {
            
            try
            {               
                if (serverPublisher == null)
                    serverPublisher = new ServerPublisher(ipAddress, portNumber);
                return Request.CreateResponse(HttpStatusCode.OK, serverPublisher.SendPing());
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
                       
                     

        }
    }
}
