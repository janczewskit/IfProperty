using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IfProperty.Tests
{
    public static class ValidatorExtensions
    {
        public static bool IsValid(this object instance, List<ValidationResult> validationResults = null) =>
            Validator.TryValidateObject(instance, new ValidationContext(instance, null, null), validationResults, true);
    }
}