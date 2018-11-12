using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using static Entities.Database;

namespace ParkingAPI.Controllers
{
    /// <summary>
    /// This is where I give you all the information about clients registered at the parking facility.
    /// </summary>
    public class ParkClientController : ApiController
    {
        /// <summary>
        /// Returns a list of all the park clients.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        // GET: api/ParkClient}
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            try
            {
                return request.CreateResponse(HttpStatusCode.OK, ReadParkClients());
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets a ParkClient based on a given licenseplate number.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="licenseNumber">The licensenumber that the client is registered with. Consists of two letters and five numbers.</param>
        /// <returns>A client with the given licensenumber</returns>
        // GET: api/ParkClient/XX00000
        public HttpResponseMessage Get(HttpRequestMessage request, string licenseNumber)
        {
            try
            {
                return request.CreateResponse(HttpStatusCode.OK, ReadParkClient(licenseNumber));
            }
            catch
            {

                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Returns a list of all registered licenseplate numbers.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/ParkClient/GetLicenseNumbers")]
        public HttpResponseMessage GetLicenseNumbers(HttpRequestMessage request)
        {
            try
            {
                return request.CreateResponse(HttpStatusCode.OK, ReadLicenseNumbers());
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Register a new client
        /// </summary>
        /// <param name="request"></param>
        /// <param name="data">A struct containing the necessary data to register a new client, licensenumber and company parking code</param>
        // POST: api/ParkClient
        public HttpResponseMessage Post(HttpRequestMessage request, ClientData data)
        {
            try
            {
                CreateParkClient(data);
                return request.CreateResponse(HttpStatusCode.Created);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.Conflict);
            }
        }

        /// <summary>
        /// Updates an existing client.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="licenseNumber">The licensenumber that the client is registered with.</param>
        /// <param name="companyParkingCode">The parking code to be updated.</param>
        // PUT: api/ParkClient/5
        public HttpResponseMessage Put(HttpRequestMessage request, string licenseNumber, string companyParkingCode)
        {
            try
            {
                UpdateParkClient(licenseNumber, companyParkingCode);
                return request.CreateResponse(HttpStatusCode.Created);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }


        /// <summary>
        /// Deletes a client from the database.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="licenseNumber">The licensenumber that the client is registered with.</param>
        // DELETE: api/ParkClient/5
        public HttpResponseMessage Delete(HttpRequestMessage request, string licenseNumber)
        {
            try
            {
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}
