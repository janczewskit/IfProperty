using System.Text.RegularExpressions;

namespace IfProperty.Expressions
{
    internal class IfPropertyNotRegexMatchExpression : IIfPropertyExpression  
    {
        public string ErrorMessage => "not a match to";

        public bool IsValid(object value, object dependentValue)
        {
            return !Regex.Match((value ?? string.Empty).ToString(), dependentValue.ToString()).Success;
        }
    }
}