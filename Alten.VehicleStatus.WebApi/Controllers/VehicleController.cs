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
    public class VehicleController : ApiController
    {
        // GET: api/Items
        public HttpResponseMessage Get(/*int skip, int take*/)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new VehicleBLL().GetAll());
        }

        // GET: api/Items/5
        public HttpResponseMessage Get(int id)
        {

            return Request.CreateResponse(HttpStatusCode.OK, new VehicleBLL().GetById(id));
        }

        // POST: api/Items
        [HttpPost]
        [Route("api/Items/Add")]
        public HttpResponseMessage Add([FromBody]Vehicle entity)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new VehicleBLL().Add(entity));
        }

        // PUT: api/Items/5
        [HttpPost]
        [Route("api/Items/Update")]
        public HttpResponseMessage Update([FromBody]Vehicle entity)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new VehicleBLL().Update(entity));
        }

        // DELETE: api/Items/5
        public HttpResponseMessage Delete([FromBody]Vehicle entity)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new VehicleBLL().Delete(entity));
        }
    }
}
