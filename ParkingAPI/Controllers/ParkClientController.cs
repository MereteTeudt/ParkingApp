using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
            return Database.ReadParkClients();
        }

        /// <summary>
        /// Gets a ParkClient based on a given licenseplate number.
        /// </summary>
        /// <param name="licenseNumber">The licensenumber that the client is registered with. Consists of two letters and five numbers.</param>
        /// <returns>A client with the given licensenumber</returns>
        // GET: api/ParkClient/XX00000
        public ParkClient Get(string licenseNumber)
        {
            return Database.ReadParkClient(licenseNumber);
        }

        /// <summary>
        /// Gets a list of licenseplate numbers registered in the database.
        /// </summary>
        /// <returns>A list of licensenumbers in the database.</returns>
        [Route("api/ParkClient/GetLicenseNumbers")]
        public List<string> GetLicenseNumbers()
        {
            return Database.ReadLicenseNumbers();
        }

        /// <summary>
        /// Registers a new client.
        /// </summary>
        /// <param name="client">The required information in the client object is the companyparkingcode and the licensenumber.</param>
        // POST: api/ParkClient
        public void Post(ParkClient client)
        {
            Database.CreateParkClient(client);
        }

        /// <summary>
        /// Updates an existing client.
        /// </summary>
        /// <param name="licenseNumber">The licensenumber that the client is registered with.</param>
        // PUT: api/ParkClient/5
        public void Put(string licenseNumber)
        {
            Database.UpdateParkClient(licenseNumber);
        }

        
        /// <summary>
        /// Deletes a client from the database.
        /// </summary>
        /// <param name="licenseNumber">The licensenumber that the client is registered with.</param>
        // DELETE: api/ParkClient/5
        public void Delete(string licenseNumber)
        {
            Database.DeleteParkClient(licenseNumber);
        }
    }
}
