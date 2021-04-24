using System.Text.RegularExpressions;

namespace IfProperty.Expressions
{
    internal class IfPropertyRegexMatchExpression : IIfPropertyExpression
    {
        public string ErrorMessage => "a match to";

        public bool IsValid(object value, object dependentValue)
        {
            return Regex.Match((value ?? string.Empty).ToString(), dependentValue.ToString()).Success;
        }
    }
}