using Alten.VehicleStatus.Business;
using Alten.VehicleStatus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Alten.VehicleStatus.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Items
        public HttpResponseMessage Get(int skip, int take)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new CustomerBLL().GetAll(skip, take));
        }

        // GET: api/Items/5
        public HttpResponseMessage Get(int id)
        {

            return Request.CreateResponse(HttpStatusCode.OK, new CustomerBLL().GetById(id));
        }

        // POST: api/Items
        [HttpPost]
        [Route("api/Items/Add")]
        public HttpResponseMessage Add([FromBody]Customer entity)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new CustomerBLL().Add(entity));
        }

        // PUT: api/Items/5
        [HttpPost]
        [Route("api/Items/Update")]
        public HttpResponseMessage Update([FromBody]Customer entity)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new CustomerBLL().Update(entity));
        }

        // DELETE: api/Items/5
        public HttpResponseMessage Delete([FromBody]Customer entity)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new CustomerBLL().Delete(entity));
        }
    }
}
