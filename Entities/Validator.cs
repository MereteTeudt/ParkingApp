using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Validator
    {
        public static void LicenseNumberValidation(string licenseNumber)
        {
            if (licenseNumber.Length != 7)
            {
                throw new ArgumentException("A licenseplate number consists of two letters and five digits.");
            }
            if (!Char.IsLetter(licenseNumber[0]) || !Char.IsLetter(licenseNumber[1]))
            {
                throw new ArgumentException("The first two characters of a licenseplate number must be letters.");
            }
            for (int i = 2; i < 7; i++)
            {
                if (!Char.IsDigit(licenseNumber[i]))
                {
                    throw new ArgumentException("The last five characters of a lincenseplate number must be digits.");
                }
            }
        }

        public static void CompanyParkingCodeValidation(string parkingCode)
        {
            if (parkingCode.Length != 5)
            {
                throw new ArgumentException("A company parking code must consist of exactly five letters.");
            }
            for (int i = 0; i < 5; i++)
            {
                if (!Char.IsLetter(parkingCode[i]))
                {
                    throw new ArgumentException("A company parking code may only consist of letters.");
                }
            }
        }
    }
}
