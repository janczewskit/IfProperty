using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace IfProperty.RequiredExtensions
{
    public class RequiredIf : RequiredAttribute
    {
        private readonly string otherProperty;
        private readonly object otherPropertyValue;

        public RequiredIf(string otherProperty, object otherPropertyValue)
        {
            this.otherProperty = otherProperty;
            this.otherPropertyValue = otherPropertyValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(otherProperty);
            if (otherPropertyInfo == null)
                return new ValidationResult($"Unknown property {otherProperty}");

            object otherValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            return Equals(otherPropertyValue, otherValue) ? base.IsValid(value, validationContext) : null;
        }
    }
}
