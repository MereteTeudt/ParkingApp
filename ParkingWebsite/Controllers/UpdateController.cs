﻿using Entities;
using ParkingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ParkingWebsite.Controllers
{
    public class UpdateController : Controller
    {
        // GET: Update
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Result(ClientModel client)
        {
            ResponseModel responseModel = new ResponseModel();
            if(ModelState.IsValid)
            {
                HttpResponseMessage responseMessage = ApiAccess.ApiProcessor(client, "Put").Result;

                if(responseMessage.StatusCode == HttpStatusCode.Conflict)
                {
                    responseModel.ResponseMessage = "The submitted parking code is not valid.";

                    return View("Response", responseModel);
                }
                else if (responseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    responseModel.ResponseMessage = "The submitted license number is not registered.";

                    return View("Response", responseModel);
                }
                else
                {
                    responseModel.ResponseMessage = "The client was successfully updated.";

                    return View("Response", responseModel);
                }
            }
            else
            {
                return View("Index", client);
            }
        }
    }
}