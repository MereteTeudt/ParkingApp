using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Entities.Tests
{
    public class ParkingCodeTest
    {
        [Fact]
        public void GenerateParkingCode_CodeIncrementing()
        {
            // Arrange
            ParkClient parkClient = new ParkClient();
            List<string> parkingCodes = new List<string>();
            // Act
            for(int i = 0; i < 5; i++)
            {
                parkingCodes.Add(parkClient.GenerateParkingCode());
            }
            // Assert
            Assert.NotEqual(parkingCodes[0], parkingCodes[1]);
        }
    }
}
