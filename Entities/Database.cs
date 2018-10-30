using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class Database
    {
        public static List<ParkClient> ParkClients = new List<ParkClient>(GenerateDatabase());

        public static string Test { get; set; }

        public static List<ParkClient> GenerateDatabase()
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
