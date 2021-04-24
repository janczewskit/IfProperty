namespace IfProperty.Expressions
{
    internal class IfPropertyNotEqualToExpression : IIfPropertyExpression
    {
        public string ErrorMessage => "not equal to";

        public bool IsValid(object value, object dependentValue)
        {
            if (value == null)
                return dependentValue != null;

            return !value.Equals(dependentValue);
        }
    }
}