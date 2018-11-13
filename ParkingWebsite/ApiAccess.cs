using ParkingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ParkingWebsite
{
    public class ApiAccess
    {
        private static string baseUrl = "http://localhost:6185/api/ParkClient";
        public static async Task<HttpResponseMessage> ApiProcessor(ClientModel client)
        {
            ApiHelper.InitializeClient();

            string url = $"{baseUrl}?LicenseNumber={client.LicensePlateNumber}&CompanyParkingCode={client.CompanyParkingCode}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                return response;
            }
        }
    }
}