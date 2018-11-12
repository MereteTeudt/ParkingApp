using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ParkingWebsite
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            //New instance of HttpClient. HttpClient class provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.
            ApiClient = new HttpClient();
            //Clears the Accept field in the header
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            // Adds a request for a response in json format so that it can be parsed into a model
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}