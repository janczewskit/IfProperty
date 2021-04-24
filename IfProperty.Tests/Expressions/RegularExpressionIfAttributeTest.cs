using NUnit.Framework;
using static IfProperty.IsOperatorEnumeration;

namespace IfProperty.Tests.Expressions
{    
    [TestFixture]
    public class RegularExpressionIfAttributeTest
    {
        [TestCase("test@test.com", ExpectedResult = true)]
        [TestCase("test*test", ExpectedResult = false)]
        public bool MatchTest(string value)
        {
            var model = new Model { Value = value };
            return model.IsValid();
        }

        [TestCase("test@test.com", ExpectedResult = false)]
        [TestCase("test*test", ExpectedResult = true)]
        public bool NotMatchTest(string value)
        {
            var model = new ModelNotMatch { Value = value };
            return model.IsValid();
        }

        private class Model
        {
            [Is(RegExMatch, Value = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
            public string Value { get; set; }
        }

        private class ModelNotMatch
        {
            [Is(NotRegExMatch, Value = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
            public string Value { get; set; }
        }
    }
}
