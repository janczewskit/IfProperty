namespace IfProperty.Expressions
{
    internal class IfPropertyEqualToExpression : IIfPropertyExpression
    {
        public string ErrorMessage => "equal to";

        public bool IsValid(object value, object dependentValue)
        {
            if (value == null)
                return dependentValue == null;

            return value.Equals(dependentValue);
        }
    }
}