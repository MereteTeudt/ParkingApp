using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web.UI.WebControls;
using Dapper;

namespace Entities
{
    public static class Database
    {
        public struct ClientData
        {
            public string CompanyParkingCode { get; set; }
            public string LicenseNumber { get; set; }
        }
        public static string ConString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// CREATE
        /// </summary>
        /// <param name="licenseNumber"></param>
        /// <param name="companyParkingCode"></param>
        public static void CreateParkClient(ClientData data)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConString("ParkingDatabase")))
            {
                ParkClient client = new ParkClient();
                LicensePlate licensePlate = new LicensePlate();
                licensePlate.LicenseNumber = data.LicenseNumber;
                client.LicensePlate = licensePlate;
                client.CompanyParkingCode = data.CompanyParkingCode;
                if (RegisteredLicensePlate(client.LicensePlate.LicenseNumber))
                {
                    throw new ArgumentException("The submitted licensenumber is already registered.");
                }
                else
                { 
                    if (VerifyParkingCode(client.CompanyParkingCode))
                    {
                        connection.Execute("INSERT INTO ParkClients (CompanyParkingCode) VALUES (@CompanyParkingCode)", new { @CompanyParkingCode = client.CompanyParkingCode });
                        string parkClientIDKey = connection.ExecuteScalar("SELECT MAX(ParkClientID) FROM ParkClients WHERE CompanyParkingCode = @CompanyParkingCode", new { @CompanyParkingCode = client.CompanyParkingCode }).ToString();
                        connection.Execute("INSERT INTO LicensePlates (ParkClientIDKey, LicenseNumber) VALUES (@ParkClientIDKey, @LicenseNumber)", new { @ParkClientIDKey = parkClientIDKey, @LicenseNumber = client.LicensePlate.LicenseNumber });
                    }
                    else
                    {
                        throw new ArgumentException("The submitted parking code is not valid.");
                    }
                }
                
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
                try
                {
                    licensePlate = connection.QuerySingle<LicensePlate>("SELECT * FROM LicensePlates WHERE LicenseNumber = @LicenseNumber", new { @LicenseNumber = licenseNumber });
                }
                catch (InvalidOperationException)
                {
                    throw;
                }
                licensePlate= connection.QuerySingle<LicensePlate>("SELECT * FROM LicensePlates WHERE LicenseNumber = @LicenseNumber", new { @LicenseNumber = licenseNumber });
                parkClient = connection.QuerySingle<ParkClient>("SELECT * FROM ParkClients WHERE ParkClientID = @ParkClientIDKey", new { @ParkClientIDKey = licensePlate.ParkClientIDKey });
                parkClient.LicensePlate = licensePlate;
                return parkClient;
            }
        }
        public static List<string> ReadLicenseNumbers()
        {
            List<string> licenseNumbers = new List<string>();
            List<ParkClient> parkClients = ReadParkClients();
            foreach(ParkClient client in parkClients)
            {
                licenseNumbers.Add(client.LicensePlate.LicenseNumber);
            }
            return licenseNumbers;
        }
        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="client"></param>
        public static void UpdateParkClient(string licenseNumber, string companyParkingCode)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConString("ParkingDatabase")))
            {
                if(RegisteredLicensePlate(licenseNumber))
                {
                    if (VerifyParkingCode(companyParkingCode))
                    {
                        ParkClient client = new ParkClient();
                        client = ReadParkClient(licenseNumber);

                        connection.Execute("UPDATE ParkClients SET CompanyParkingCode = @CompanyParkingCode WHERE ParkClientID = @ParkClientID", new { @CompanyParkingCode = companyParkingCode, @ParkClientID = client.ParkClientID });
                        connection.Execute("UPDATE LicensePlates SET LicenseNumber = @LicenseNumber WHERE LicensePlateID = @LicensePlateID", new { @LicenseNumber = client.LicensePlate.LicenseNumber, @LicensePlateID = client.LicensePlate.LicensePlateID });
                        connection.Execute("UPDATE LicensePlates SET ParkClientIDKey = @ParkClientIDKey WHERE LicensePlateID = @LicensePlateID", new { @ParkClientIDKey = client.LicensePlate.ParkClientIDKey, @LicensePlateID = client.LicensePlate.LicensePlateID });
                    }
                    else
                    {
                        throw new ArgumentException("The submitted parking code is not valid.");
                    }
                }
                else
                {
                    throw new ArgumentException("The submitted licenseplate number is not registered.");
                }
            }
        }
        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="client"></param>
        public static void DeleteParkClient(string licenseNumber)
        {
            ParkClient client = new ParkClient();
            try
            {
                client = ReadParkClient(licenseNumber);
            }
            catch
            {
                throw;
            }
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConString("ParkingDatabase")))
            {
                client.LicensePlate = connection.QuerySingle<LicensePlate>("SELECT * FROM LicensePlates WHERE LicenseNumber = @LicenseNumber", new { @LicenseNumber = licenseNumber });
                connection.Execute("DELETE FROM LicensePlates WHERE LicensePlateID = @LicensePlateID", new { @LicensePlateID = client.LicensePlate.LicensePlateID });
                connection.Execute("DELETE FROM ParkClients WHERE ParkClientID = @ParkClientID", new { @ParkClientID = client.ParkClientID });
            }
        }

        public static bool VerifyParkingCode(string parkingCode)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConString("ParkingDatabase")))
            {
                Validator.CompanyParkingCodeValidation(parkingCode);
                bool result = connection.ExecuteScalar<bool>("SELECT 1 WHERE EXISTS (SELECT 1 FROM ParkingCodes WHERE Code = @Code)", new { @Code = parkingCode });
                return result;
            }
        }

        public static bool RegisteredLicensePlate(string licenseNumber)
        {
            try
            {
                ReadParkClient(licenseNumber);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void GenerateDatabase()
        {
            List<ClientData> clients = new List<ClientData>();
            for (int i = 0; i < 10; i++)
            {
                ClientData data = new ClientData();
                LicensePlate licensePlate = new LicensePlate();
                ParkClient parkClient = new ParkClient();
                data.LicenseNumber = licensePlate.GenerateLicensePlate().LicenseNumber;
                data.CompanyParkingCode = parkClient.GenerateParkingCode();
                clients.Add(data);
            }
            foreach (ClientData data in clients)
            {
                CreateParkClient(data);
            }
        }

    }
}
