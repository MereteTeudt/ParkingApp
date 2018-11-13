using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ParkingWebsite.Models.CustomValidationAttributes
{
    public class ParkingCodeValidator : ValidationAttribute
    {
        private string parkingCode;

        public ParkingCodeValidator(string code)
        {
            parkingCode = code;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ClientModel clientModel = (ClientModel)validationContext.ObjectInstance;

            Regex regexLetters = new Regex("A-Za-z");

            if (regexLetters.IsMatch(clientModel.CompanyParkingCode))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(GetErrorMessage());
        }

        private string GetErrorMessage()
        {
            return $"Parkingcodes must contain only letters. Your input was {parkingCode}.";
        }
    }
}