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
        private static string url = "http://localhost:6185/api/ParkClient";
        public static async Task<HttpResponseMessage> ApiProcessor(ClientModel client, string typeOfCall)
        {
            ApiHelper.InitializeClient();

            if (typeOfCall == "Post")
            {
                
                using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, client))
                {
                    return response;
                }
            }
            else if (typeOfCall == "Put")
            {

                using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, client))
                {
                    return response;
                }
            }
            else
            {

                using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, client))
                {
                    return response;
                }
            }
        }
    }
}