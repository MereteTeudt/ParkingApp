using Entities;
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
            ResponseModel response = new ResponseModel();
            response.Success = ModelState.IsValid;
            if(response.Success)
            {
                HttpResponseMessage responseMessage = ApiAccess.ApiProcessor(client, "Post").Result;

                if(responseMessage.StatusCode == HttpStatusCode.Conflict)
                {
                    response.ResponseMessage = "The submitted parking code is not valid.";

                    return View("Response", response);
                }
                else
                {
                    response.ResponseMessage = "The submitted license number is not registered.";

                    return View("Response", response);
                }
            }
            else
            {
                return View("Index", client);
            }
        }
    }
}