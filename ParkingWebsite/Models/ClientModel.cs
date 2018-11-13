using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkingWebsite.Models
{
    public class ClientModel
    {
        [Required(ErrorMessage = "A parking code is required.")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "A parkingcode must be 5 characters long")]
        public string CompanyParkingCode { get; set; }

        [Required(ErrorMessage = "A license number is required.")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "A licensenumber must be 7 characters long")]
        public string LicensePlateNumber { get; set; }
    }
}