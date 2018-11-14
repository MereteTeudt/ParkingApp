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
        private static string baseUrl = "http://localhost:6185";
        private static string requestUri = "/api/ParkClient";
        private static string deleteUri = requestUri;
        public static async Task<HttpResponseMessage> ApiProcessor(ClientModel client, string typeOfCall)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);

            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("LicenseNumber", client.LicensePlateNumber));
            list.Add(new KeyValuePair<string, string>("CompanyParkingCode", client.CompanyParkingCode));

            var content = new FormUrlEncodedContent(list);


            if (typeOfCall == "Post")
            {
                using (httpClient)
                {
                    HttpResponseMessage response = httpClient.PostAsync(requestUri, content).Result;

                    return response;
                }
            }
            else if (typeOfCall == "Put")
            {

                using (httpClient)
                {
                    HttpResponseMessage response = httpClient.PutAsync(requestUri, content).Result;

                    return response;
                }
            }
            else
            {
                deleteUri += $"?licenseNumber={client.LicensePlateNumber}";
                using (httpClient)
                {
                    HttpResponseMessage response = httpClient.DeleteAsync(deleteUri).Result;

                    return response;
                }
            }
        }
    }
}