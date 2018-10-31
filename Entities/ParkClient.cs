using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ParkClient
    {
        public int ParkClientID { get; }
        public LicensePlate LicensePlate { get; set; }

        public string CompanyParkingCode { get; set; }

        private static char[] Code = new char[] { 'A', 'A', 'A', 'A', 'A' };

        public string GenerateParkingCode()
        {

            if (Code[4] < 'z')
            {
                Code[4]++;
            }
            else if (Code[3] < 'z')
            {
                Code[3] ++;
            }
            else if (Code[2] < 'z')
            {
                Code[2] ++;
            }
            else if (Code[1] < 'z')
            {
                Code[1]++;
            }
            else if (Code[0] < 'z')
            {
                Code[0]++;
            }

            return new string(Code);
        }
    }
}
