﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ParkingAPI.Controllers
{
    public class UpdateController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UnRegistered()
        {
            return View();
        }
    }
}
