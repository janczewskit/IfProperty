using System.Collections.Generic;

namespace IfProperty.Expressions
{
    internal class IfPropertyLessThanExpression : IIfPropertyExpression
    {
        public string ErrorMessage => "less than";

        public bool IsValid(object value, object dependentValue)
        {
            if (value == null || dependentValue == null)
                return false;

            return Comparer<object>.Default.Compare(value, dependentValue) <= -1;
        }
    }
}