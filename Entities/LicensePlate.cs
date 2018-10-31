using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LicensePlate
    {

        public LicensePlate(string licenseNumber)
        {
            LicenseNumber = licenseNumber;
        }

        public LicensePlate()
        {
        }
        public string LicenseNumber { get; set; }

        private static readonly Random random = new Random();

        public string RandomChars()
        {
            string randomChars = "";
            for(int i = 0; i < 2; i++)
            {
                int num = random.Next(0, 26);
                randomChars += (char)('a' + num);
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
