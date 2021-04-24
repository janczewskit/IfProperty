using System.Linq;
using static IfProperty.IsOperatorEnumeration;

namespace IfProperty.Expressions
{
    internal class IfPropertyInExpression : IIfPropertyExpression
    {
        public string ErrorMessage => "in";

        public bool IsValid(object value, object dependentValue)
        {
            IIfPropertyExpression isEqualExpression = IfPropertyExpressionsContainer.Get(EqualTo);
            if (dependentValue is object[] values)
                return values.Any(val => isEqualExpression.IsValid(value, val));

            return isEqualExpression.IsValid(value, dependentValue);
        }
    }
}