using Entities;
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
        private string baseUrl = $"http://localhost:6185/api/ParkClient";

        // GET: Update
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Result(string licenseNumber, string companyParkingCode)
        {
            string url = baseUrl + "?LicenseNumber=" + licenseNumber + "&CompanyParkingCode=" + companyParkingCode;
            using (HttpResponseMessage response = ApiHelper.ApiClient.GetAsync(url).Result)
            {
                if(response.IsSuccessStatusCode)
                {
                    return View("ResultPositive");
                }
                else
                {
                    return View("ResultNegative");
                }
            }
        }
    }
}