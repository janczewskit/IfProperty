using System.Collections.Generic;
using static IfProperty.IsOperatorEnumeration;

namespace IfProperty.Expressions
{
    internal class IfPropertyLessThanOrEqualToExpression : IIfPropertyExpression
    {
        public string ErrorMessage => "less than or equal to";

        public bool IsValid(object value, object dependentValue)
        {
            if (value == null && dependentValue == null)
                return true;

            if (value == null || dependentValue == null)
                return false;

            return IfPropertyExpressionsContainer.Get(EqualTo).IsValid(value, dependentValue)
                   || Comparer<object>.Default.Compare(value, dependentValue) <= -1;
        }
    }
}