using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Database
    {
        public Database()
        {
            ParkClients = new List<ParkClient>()
            {
                new ParkClient() { LicensePlate = new LicensePlate("AA11111"), CompanyparkCode = "XXXX1"},
                new ParkClient() { LicensePlate = new LicensePlate("AA22222"), CompanyparkCode = "XXXX2"},
                new ParkClient() { LicensePlate = new LicensePlate("AA33333"), CompanyparkCode = "XXXX3"}
            };
        }
        public List<ParkClient> ParkClients { get; set; }

        public List<ParkClient> GenerateDatabase()
        {
            ParkClients = new List<ParkClient>();
            for (int i = 0; i < 100; i++)
            {
                LicensePlate licensePlate = new LicensePlate();
                ParkClient parkClient = new ParkClient();
                parkClient.LicensePlate = licensePlate.GenerateLicensePlate();
                ParkClients.Add(parkClient);
            }
            return ParkClients;
        }
    }
}
