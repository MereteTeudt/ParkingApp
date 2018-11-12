using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LicensePlate
    {
        private string licenseNumber;
        /// <summary>
        /// ID from SQL
        /// </summary>
        public int LicensePlateID { get; set; }

        /// <summary>
        /// Foreign key for SQL
        /// </summary>
        public int ParkClientIDKey { get; set; }

        /// <summary>
        /// The number on the licenseplate, consists of two letters and five numbers
        /// </summary>
        public string LicenseNumber
        {
            get
            {
                return licenseNumber;
            }

            set
            {
                Validator.LicenseNumberValidation(value);
                licenseNumber = value;
            }
        }

        private static readonly Random random = new Random();

        public LicensePlate(string licenseNumber)
        {
            LicenseNumber = licenseNumber;
        }

        public LicensePlate()
        {
        }

        public string RandomChars()
        {
            string randomChars = "";
            for(int i = 0; i < 2; i++)
            {
                int num = random.Next(0, 26);
                randomChars += (char)('A' + num);
            }
            return randomChars;
        }

        public string RandomNums()
        {
            string randomNums = "";
            for(int i = 0; i < 5; i++)
            {
                randomNums += random.Next(0, 10);
            }
            return randomNums;
        }

        public LicensePlate GenerateLicensePlate()
        {
            LicensePlate licensePlate = new LicensePlate();
            licensePlate.LicenseNumber = RandomChars() + RandomNums();

            return licensePlate;
        }
    }
}
