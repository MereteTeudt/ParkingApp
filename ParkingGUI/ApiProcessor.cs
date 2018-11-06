using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGUI
{
    public class ApiProcessor
    {
        public static async Task<bool> GetParkClient(string licenseNumber)
        {
            string url = "http://localhost:6185/api/ParkClient?licenseNumber=";
            url += licenseNumber;
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
