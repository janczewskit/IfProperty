using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace IfProperty.RequiredExtensions
{
    public class RequiredIfNotNull : RequiredAttribute
    {
        private readonly string otherProperty;

        public RequiredIfNotNull(string otherProperty) => this.otherProperty = otherProperty;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(otherProperty);
            if (otherPropertyInfo == null)
                return new ValidationResult($"Unknown property {otherProperty}");

            object otherValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            return otherValue != null ? base.IsValid(value, validationContext) : null;
        }
    }
}
