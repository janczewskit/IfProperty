using System.Linq;
using static IfProperty.IsOperatorEnumeration;

namespace IfProperty.Expressions
{
    internal class IfPropertyNotInExpression : IIfPropertyExpression
    {
        public string ErrorMessage => "not in";

        public bool IsValid(object value, object dependentValue)
        {
            IIfPropertyExpression isEqualExpression = IfPropertyExpressionsContainer.Get(EqualTo);
            if (dependentValue is object[] values)
                return values.All(val => !isEqualExpression.IsValid(value, val));

            return !isEqualExpression.IsValid(value, dependentValue);
        }
    }
}