﻿using Alten.VehicleStatus.Interface.PublisherSubscriber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alten.VehicleStatus.Interface.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle       
        public ActionResult Index()
        {
            return View();
        }

    }
}