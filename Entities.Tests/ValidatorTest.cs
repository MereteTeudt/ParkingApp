using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Entities.Tests
{
    public class ValidatorTest
    {
        [Fact]
        public void LicenseNumberValidation_ValidateLicenseNumber()
        {
            // Arrange 
            string licenseNumberOne = "AA5555";
            string licenseNumberTwo = "AAAAAAA";
            string licenseNumberThree = "555555";
            string licenseNumberCorrect = "AA55555";
            LicensePlate licensePlate = new LicensePlate();
            // Act
            Action actOne = () => Validator.LicenseNumberValidation(licenseNumberOne);
            Action actTwo = () => Validator.LicenseNumberValidation(licenseNumberTwo);
            Action actThree = () => Validator.LicenseNumberValidation(licenseNumberThree);
            licensePlate.LicenseNumber = licenseNumberCorrect;
            //Assert
            Assert.Throws<ArgumentException>(actOne);
            Assert.Throws<ArgumentException>(actTwo);
            Assert.Throws<ArgumentException>(actThree);
            Assert.Equal(licenseNumberCorrect, licensePlate.LicenseNumber);
        }

        [Fact]
        public void CompanyParkingCodeValidation_ValidateParkingCode()
        {
            // Arrange
            string companyParkingCodeTooShort = "AAAA";
            string companyParkingCodeContainsDigits = "AAAA5";
            string companyParkingCodeCorrect = "AAAAA";
            ParkClient client = new ParkClient();
            // Act
            Action actOne = () => Validator.CompanyParkingCodeValidation(companyParkingCodeTooShort);
            Action actTwo = () => Validator.CompanyParkingCodeValidation(companyParkingCodeContainsDigits);
            client.CompanyParkingCode = companyParkingCodeCorrect;
            // Assert
            Assert.Throws<ArgumentException>(actOne);
            Assert.Throws<ArgumentException>(actTwo);
            Assert.Equal(companyParkingCodeCorrect, client.CompanyParkingCode);
        }
    }
}
