using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Xunit;

namespace Entities.Tests
{
    public class RandomTest
    {

        [Fact]
        public void RamdomChars_GenerateRandomChar()
        {
            // Arrange
            LicensePlate licencePlateOne = new LicensePlate();
            // Act
            string chars = licencePlateOne.RandomChars();
            char firstLetter = chars[0];
            char secondLetter = chars[1];
            // Assert
            Assert.NotEqual(firstLetter, secondLetter);
        }

        [Fact]
        public void RandomChars_GenerateRandomSetsOfChars()
        {
            // Arrange
            LicensePlate licencePlateOne = new LicensePlate();
            // Act
            string charsOne = licencePlateOne.RandomChars();
            string charsTwo = licencePlateOne.RandomChars();
            // Assert
            Assert.NotEqual(charsOne, charsTwo);
        }

        [Fact]
        public void RandomNums_GenerateRandomNum()
        {
            // Arrange
            LicensePlate licencePlateOne = new LicensePlate();
            // Act
            string nums = licencePlateOne.RandomNums();
            char firstNumber = nums[0];
            char secondNumber = nums[1];
            // Assert
            Assert.NotEqual(firstNumber, secondNumber);
        }

        [Fact]
        public void RandomChars_GenerateRandomSetsOfNums()
        {
            // Arrange
            LicensePlate licencePlateOne = new LicensePlate();
            // Act
            string numsOne = licencePlateOne.RandomNums();
            string numsTwo = licencePlateOne.RandomNums();
            // Assert
            Assert.NotEqual(numsOne, numsTwo);
        }

        [Fact]
        public void GenerateLicensePlate_GenerateALicensePlate()
        {
            // Arrange
            LicensePlate licencePlateOne = new LicensePlate();
            int expected = 7;
            // Act
            licencePlateOne = licencePlateOne.GenerateLicensePlate();
            int actual = licencePlateOne.LicenseNumber.Length;
            // Assert
            Assert.Equal(expected, actual);
        }

        /*[Fact]
        public void GenerateDatabase_GenerateListOfParkClients()
        {
            // Arrange / Act
            Database.ParkClients = Database.GenerateDatabase();
            ParkClient first = Database.ParkClients[0];
            ParkClient second = Database.ParkClients[1];
            // Assert
            Assert.NotEqual(first.LicensePlate, second.LicensePlate);
        }*/

        [Fact]
        public void GenerateLicensePlate_GenerateDifferentLicensePlates()
        {
            // Arrange
            List<LicensePlate> licensePlates = new List<LicensePlate>();
            // Act
            for (int i = 0; i < 10; i++)
            {
                LicensePlate licensePlate = new LicensePlate();
                licensePlates.Add(licensePlate.GenerateLicensePlate());
            }
            // Assert
            Assert.NotEqual(licensePlates[0].LicenseNumber, licensePlates[1].LicenseNumber);
        }
    }
}
