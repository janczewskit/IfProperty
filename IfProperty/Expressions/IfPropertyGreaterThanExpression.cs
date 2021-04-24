using System.Collections.Generic;

namespace IfProperty.Expressions
{
    internal class IfPropertyGreaterThanExpression : IIfPropertyExpression
    {
        public string ErrorMessage => "greater than";

        public bool IsValid(object value, object dependentValue)
        {
            if(value == null || dependentValue == null)
                return false;

            return Comparer<object>.Default.Compare(value, dependentValue) >= 1;
        }
    }
}