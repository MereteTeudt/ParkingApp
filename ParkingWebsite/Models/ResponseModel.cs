using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkingWebsite.Models
{
    public class ResponseModel
    {
        [Required]
        public bool Success { get; set; }

        [Required]
        public string ResponseMessage { get; set; }
    }
}