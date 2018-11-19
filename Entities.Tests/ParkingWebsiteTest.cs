using ParkingWebsite;
using ParkingWebsite.Controllers;
using ParkingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Entities.Tests
{
    public class ParkingWebsiteTest
    {

        [Fact]
        public void ApiProcessor_ReturnsHttpResponseOnPut()
        {
            // Arrange
            ClientModel clientModel = new ClientModel();
            clientModel.CompanyParkingCode = "AAAAF";
            clientModel.LicensePlateNumber = "HI98466";
            HttpResponseMessage expectedResponse = new HttpResponseMessage();
            expectedResponse.StatusCode = System.Net.HttpStatusCode.OK;
            string expectedString = expectedResponse.StatusCode.ToString();

            // Act
            HttpResponseMessage actualResponse = ApiAccess.ApiProcessor(clientModel, "Put").Result;
            string actualString = actualResponse.StatusCode.ToString();

            // Assert
            Assert.Equal(expectedString, actualString);
        }

        [Fact]
        public void ApiProcessor_ReturnsHttpResponseOnCreateAndDelete()
        {
            // Arrange
            ClientModel clientModel = new ClientModel();
            clientModel.CompanyParkingCode = "AAAAB";
            clientModel.LicensePlateNumber = "AA11111";

            HttpResponseMessage expectedCreateResponse = new HttpResponseMessage();
            expectedCreateResponse.StatusCode = System.Net.HttpStatusCode.Created;
            string expectedCreateString = expectedCreateResponse.StatusCode.ToString();

            HttpResponseMessage expectedDeleteResponse = new HttpResponseMessage();
            expectedDeleteResponse.StatusCode = System.Net.HttpStatusCode.OK;
            string expectedDeleteString = expectedDeleteResponse.StatusCode.ToString();

            // Act
            HttpResponseMessage actualCreateResponse = ApiAccess.ApiProcessor(clientModel, "Post").Result;
            string actualCreateString = actualCreateResponse.StatusCode.ToString();
            HttpResponseMessage actualDeleteResponse = ApiAccess.ApiProcessor(clientModel, "Delete").Result;
            string actualDeleteString = actualDeleteResponse.StatusCode.ToString();

            // Assert
            Assert.Equal(expectedCreateString, actualCreateString);
            Assert.Equal(expectedDeleteString, actualDeleteString);
        }
    }
}
