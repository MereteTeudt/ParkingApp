using Entities;
using ParkingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                HttpResponseMessage responseMessage = ApiAccess.ApiProcessor(client).Result;
            }
            else
            {
                response.ResponseMessage = "Failed to update.";
                return View("Index", client);
            }
        }
    }
}