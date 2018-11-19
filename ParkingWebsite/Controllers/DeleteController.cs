using ParkingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ParkingWebsite.Controllers
{
    public class DeleteController : Controller
    {
        // GET: Delete
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Result(ClientModel client)
        {
            ResponseModel responseModel = new ResponseModel();
            if (client.LicensePlateNumber != null)
            {
                HttpResponseMessage responseMessage = ApiAccess.ApiProcessor(client, "Delete").Result;

                if (responseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    responseModel.ResponseMessage = "The submitted license number is already registered.";

                    return View("Response", responseModel);
                }
                else
                {
                    responseModel.ResponseMessage = "The client was successfully deleted.";

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