using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParkingAPI.Controllers
{
    public class ParkClientController : ApiController
    {

        // GET: api/ParkClient
        public List<ParkClient> Get()
        {
            return Database.ReadParkClients();
        }

        // GET: api/ParkClient/XX00000
        public ParkClient Get(string licenseNumber)
        {
            return Database.ReadParkClient(licenseNumber);
        }

        // POST: api/ParkClient
        public void Post(ParkClient client)
        {
            Database.CreateParkClient(client);
        }

        // PUT: api/ParkClient/5
        public void Put(ParkClient client)
        {
            Database.UpdateParkClient(client);
        }

        // DELETE: api/ParkClient/5
        public void Delete(string licenseNumber)
        {
            Database.DeleteParkClient(licenseNumber);
        }
    }
}
