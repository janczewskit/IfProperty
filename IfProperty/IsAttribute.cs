using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using IfProperty.Expressions;

namespace IfProperty
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class IsAttribute : ValidationAttribute
    {
        public string Property { get; set; }
        public object Value { get; set; }
        public bool PassOnNull { get; set; }
        public string CustomMessage { get; set; }

        private readonly IIfPropertyExpression expression;

        public IsAttribute(string expression)
        {
            this.expression = IfPropertyExpressionsContainer.Get(expression);
        }

        protected override ValidationResult IsValid(object actualValue, ValidationContext validationContext) => 
            Property != null ? IsValidProperty(actualValue, validationContext) : IsValidValue(actualValue, validationContext);

        private ValidationResult IsValidProperty(object actualValue, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(Property);
            if (otherPropertyInfo == null)
                return new ValidationResult($"Unknown property {Property}");

            object otherValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            if (ValidPassOnNull(actualValue, otherValue))
                return ValidationResult.Success;

            return !expression.IsValid(actualValue, otherValue)
                ? new ValidationResult(CustomMessage ?? $"{validationContext.MemberName} must be {expression.ErrorMessage} property {Property}.")
                : ValidationResult.Success;
        }

        private ValidationResult IsValidValue(object actualValue, ValidationContext validationContext)
        {
            if (ValidPassOnNull(actualValue, Value))
                return ValidationResult.Success;

            return !expression.IsValid(actualValue, Value)
                ? new ValidationResult(CustomMessage ?? $"{validationContext.MemberName} must be {expression.ErrorMessage} {Value}.")
                : ValidationResult.Success;
        }

        private bool ValidPassOnNull(object actualValue, object expectedValue) =>
            PassOnNull && (actualValue == null || expectedValue == null) && (actualValue != null || expectedValue != null);
    }
}