using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Entities.Database;

namespace ParkingAPI.Controllers
{
    /// <summary>
    /// This is where I give you all the information about clients registered at the parking facility.
    /// </summary>
    public class ParkClientController : ApiController
    {
        /// <summary>
        /// Gets a list of clients.
        /// </summary>
        /// <returns>A list of clients.</returns>
        // GET: api/ParkClient
        public List<ParkClient> Get()
        {
            try
            {
                return Database.ReadParkClients();
            }
            catch
            {
                throw new Exception("An unexpected error occured");
            }
        }

        /// <summary>
        /// Gets a ParkClient based on a given licenseplate number.
        /// </summary>
        /// <param name="licenseNumber">The licensenumber that the client is registered with. Consists of two letters and five numbers.</param>
        /// <returns>A client with the given licensenumber</returns>
        // GET: api/ParkClient/XX00000
        public ParkClient Get(string licenseNumber)
        {
            try
            {
                return Database.ReadParkClient(licenseNumber);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gets a list of licenseplate numbers registered in the database.
        /// </summary>
        /// <returns>A list of licensenumbers in the database.</returns>
        [Route("api/ParkClient/GetLicenseNumbers")]
        public List<string> GetLicenseNumbers()
        {
            try
            {
                return Database.ReadLicenseNumbers();
            }
            catch
            {
                throw new Exception("An unexpected error occured");
            }
        }

        /// <summary>
        /// Register a new client
        /// </summary>
        /// <param name="data">A struct containing the necessary data to register a new client, licensenumber and company parking code</param>
        // POST: api/ParkClient
        [System.Web.Mvc.HttpPost]
        public void Post(ClientData data)
        {
            try
            {
                Database.CreateParkClient(data);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Updates an existing client.
        /// </summary>
        /// <param name="licenseNumber">The licensenumber that the client is registered with.</param>
        /// <param name="companyParkingCode">The parking code to be updated.</param>
        // PUT: api/ParkClient/5
        public void Put(string licenseNumber, string companyParkingCode)
        {
            try
            {
                Database.UpdateParkClient(licenseNumber, companyParkingCode);
            }
            catch
            {
                throw;
            }
        }

        
        /// <summary>
        /// Deletes a client from the database.
        /// </summary>
        /// <param name="licenseNumber">The licensenumber that the client is registered with.</param>
        // DELETE: api/ParkClient/5
        public void Delete(string licenseNumber)
        {
            try
            {
                Database.DeleteParkClient(licenseNumber);
            }
            catch
            {
                throw;
            }
        }
    }
}
