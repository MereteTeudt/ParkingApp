using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ParkingWebsite.Models.CustomValidationAttributes
{
    public class LicenseNumberValidator : ValidationAttribute
    {
        private string licenseNumber;

        public LicenseNumberValidator(string number)
        {
            licenseNumber = number;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ClientModel clientModel = (ClientModel)validationContext.ObjectInstance;

            string letters = clientModel.LicensePlateNumber.Substring(0, 2);
            Regex regexLetters = new Regex("A-Za-z");
            string digits = clientModel.LicensePlateNumber.Substring(3, 7);
            Regex regexDigits = new Regex("0-9");

            if (regexLetters.IsMatch(letters) && regexDigits.IsMatch(digits))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(GetErrorMessage());
        }

        private string GetErrorMessage()
        {
            return $"Licensenumbers must consist of two letters and 7 digits in that order. Your input was {licenseNumber}.";
        }
    }
}