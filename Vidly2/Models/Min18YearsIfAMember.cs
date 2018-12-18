using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.DTOs;

namespace Vidly2.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var customer = (Customer)context.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.DateOfBirth == null)
            {
                return new ValidationResult("Date of Birth is required");
            }

            var age = DateTime.Now.Year - customer.DateOfBirth.Value.Year;

            if (age <= 18)
            {
                return new ValidationResult("You must be at least 18 years old to join.");
            }

            return ValidationResult.Success;

        }
    }
}