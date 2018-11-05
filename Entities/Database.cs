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

        public static string ConString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// CEATE
        /// </summary>
        /// <param name="client"></param>
        public static void CreateParkClient(ParkClient client)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConString("ParkingDatabase")))
            {
                connection.Execute("ParkingClients_Insert @CompanyParkingCode", new { @CompanyParkingCode = client.CompanyParkingCode });
                connection.Execute("LicensePlates_Insert @LicenseNumber", new { @LicenseNumber = client.LicensePlate.LicenseNumber });
                connection.Execute("LicensePlates_Insert @ParkClientIDKey", new { @ParkClientIDKey = client.LicensePlate.ParkClientIDKey });
            }
        }
        /// <summary>
        /// READ
        /// </summary>
        /// <returns></returns>
        public static List<ParkClient> ReadParkClients()
        {
            List<ParkClient> parkClients = new List<ParkClient>();
            List<LicensePlate> licensePlates = new List<LicensePlate>();
            int i = 0;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConString("ParkingDatabase")))
            {
                parkClients = connection.Query<ParkClient>("SELECT * FROM ParkClients").ToList();
                licensePlates = connection.Query<LicensePlate>("SELECT * FROM LicensePlates").ToList();
                foreach (ParkClient client in parkClients)
                {
                    client.LicensePlate = licensePlates[i];
                    i++;
                }
                return parkClients;
            }
        }
        public static ParkClient ReadParkClient(string licenseNumber)
        {
            ParkClient parkClient = new ParkClient();
            LicensePlate licensePlate = new LicensePlate();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConString("ParkingDatabase")))
            {
                licensePlate= connection.QuerySingle<LicensePlate>("SELECT * FROM LicensePlates WHERE LicenseNumber = @LicenseNumber", new { @LicenseNumber = licenseNumber });
                parkClient = connection.QuerySingle<ParkClient>("SELECT * FROM ParkClients WHERE ParkClientID = @ParkClientIDKey", new { @ParkClientIDKey = licensePlate.ParkClientIDKey });
                parkClient.LicensePlate = licensePlate;
                return parkClient;
            }
        }
        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="client"></param>
        public static void UpdateParkClient(ParkClient client)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConString("ParkingDatabase")))
            {
                connection.Execute("UPDATE ParkClients SET CompanyParkCode = @CompanyParkCode WHERE ParkClientID = @ParkClientID", new { @ParkClientID = client.ParkClientID });
                connection.Execute("UPDATE LicensePlates SET LicenseNumber = @LicenseNumber WHERE LicensePlateID = @LicensePlateID", new { @LicensePlateID = client.LicensePlate.LicensePlateID });
                connection.Execute("UPDATE LicensePlates SET ParkClientIDKey = @ParkClientIDKey WHERE LicensePlateID = @LicensePlateID", new { @LicensePlateID = client.LicensePlate.LicensePlateID });
            }
        }
        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="client"></param>
        public static void DeleteParkClient(string licenseNumber)
        {
            LicensePlate licensePlate = new LicensePlate();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConString("ParkingDatabase")))
            {
                licensePlate = connection.QuerySingle<LicensePlate>("SELECT * FROM LicensePlates WHERE LicenseNumber = @LicenseNumber", new { @LicenseNumber = licenseNumber });
                connection.Execute("DELETE FROM ParkClients WHERE ParkClientID = @ParkClientIDKey", new { @ParkClientIDKey = licensePlate.ParkClientIDKey });
                connection.Execute("DELETE FROM LicensePlates WHERE LicensePlateID = @LicensePlateID", new { @LicensePlateID = licensePlate.LicensePlateID });
            }
        }

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

    }
}
