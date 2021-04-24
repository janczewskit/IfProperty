using System.Collections.Generic;
using IfProperty.Expressions;
using static IfProperty.IsOperatorEnumeration;

namespace IfProperty
{
    public static class IfPropertyExpressionsContainer
    {
        private static readonly Dictionary<string, IIfPropertyExpression> expressions;

        static IfPropertyExpressionsContainer() => expressions = new Dictionary<string, IIfPropertyExpression>
        {
            {EqualTo, new IfPropertyEqualToExpression()},
            {NotEqualTo, new IfPropertyNotEqualToExpression()},
            {GreaterThan, new IfPropertyGreaterThanExpression()},
            {GreaterThanOrEqualTo, new IfPropertyGreaterThanOrEqualToExpression()},
            {LessThan, new IfPropertyLessThanExpression()},
            {LessThanOrEqualTo, new IfPropertyLessThanOrEqualToExpression()},
            {RegExMatch, new IfPropertyRegexMatchExpression()},
            {NotRegExMatch, new IfPropertyNotRegexMatchExpression()},
            {In, new IfPropertyInExpression()},
            {NotIn, new IfPropertyNotInExpression()},
        };

        public static IIfPropertyExpression Get(string @operator) => expressions[@operator];

        public static void AddOrOverride(string @operator, IIfPropertyExpression expression) => expressions[@operator] = expression;

        public static void Clear() => typeof(IfPropertyExpressionsContainer).TypeInitializer.Invoke(null, null);
    }
}