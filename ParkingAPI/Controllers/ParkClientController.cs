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
        Database database = new Database();

        // GET: api/ParkClient
        public List<ParkClient> Get()
        {
            return database.ParkClients;
        }

        // GET: api/ParkClient/XX00000
        public ParkClient Get(string licenseNumber)
        {
            return database.ParkClients.Where(x => x.LicensePlate.LicenseNumber == licenseNumber).FirstOrDefault();
        }

        // POST: api/ParkClient
        public void Post(ParkClient val)
        {
            database.ParkClients.Add(val);
        }

        // PUT: api/ParkClient/5
        public void Put(ParkClient val)
        {
            ParkClient parkClient = database.ParkClients.Where(x => x.LicensePlate.LicenseNumber == val.LicensePlate.LicenseNumber).FirstOrDefault();
            parkClient = val;
        }

        // DELETE: api/ParkClient/5
        public void Delete(int id)
        {
        }
    }
}
