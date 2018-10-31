using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Entities
{
    public static class Database
    {

        public static List<ParkClient> ParkClients = new List<ParkClient>(GetParkClients());

        /*public static List<ParkClient> GenerateDatabase()
        {
            ParkClients = new List<ParkClient>();
            for (int i = 0; i < 5; i++)
            {
                LicensePlate licensePlate = new LicensePlate();
                ParkClient parkClient = new ParkClient();
                parkClient.LicensePlate = licensePlate.GenerateLicensePlate();
                parkClient.CompanyParkingCode = parkClient.GenerateParkingCode();
                ParkClients.Add(parkClient);
            }
            return ParkClients;
        }*/

        public static string ConString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static List<ParkClient> GetParkClients()
        {
            List<ParkClient> parkClients = new List<ParkClient>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConString("ParkingDatabase")))
            {
                parkClients = connection.Query<ParkClient, LicensePlate, ParkClient>($"select * from ParkClients JOIN LicensePlates ON ParkClients.ParkClientID = LicensePlates.ParkClientIDKey",
                    map: (p, l) =>
                    {
                        p.LicensePlate = l;
                        return p;
                    },
                    splitOn: "ParkClientIDKey"
                    ).ToList();
                return parkClients;
            }
        }

        public static void InsertParkClient(ParkClient client)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConString("ParkingDatabase")))
            {
                connection.Execute("ParkingClients_Insert @CompanyParkingCode", client.CompanyParkingCode);
                connection.Execute("LicensePlates_Insert @LicenseNumber, @ParkClientIDKey", client.LicensePlate);
            }
        }

        public static void UpdateParkClient(ParkClient client)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConString("ParkingDatabase")))
            {
                connection.Execute("UPDATE ParkClients SET CompanyParkCode = @CompanyParkCode WHERE ParkClientID = @ParkClientID", client);
                connection.Execute("UPDATE LicensePlates SET LicenseNumber = @LicenseNumber WHERE LicensePlateID = @LicensePlateID", client.LicensePlate);
                connection.Execute("UPDATE LicensePlates SET ParkClientIDKey = @ParkClientIDKey WHERE LicensePlateID = @LicensePlateID", client.LicensePlate);
            }
        }
    }
}
