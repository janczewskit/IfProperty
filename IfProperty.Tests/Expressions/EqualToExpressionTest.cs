using NUnit.Framework;
using static IfProperty.IsOperatorEnumeration;

namespace IfProperty.Tests.Expressions
{
	[TestFixture]
    public class EqualToExpressionTest
    {
        [TestCase("hello", "hello", ExpectedResult = true)]
        [TestCase("hello", "goodbye", ExpectedResult = false)]
        [TestCase(null, null, ExpectedResult = true)]
        [TestCase(null, "hello", ExpectedResult = false)]
        [TestCase("hello", null, ExpectedResult = false)]
        public bool Test(string value1, string value2)
        {
            var model = new Model { Value1 = value1, Value2 = value2 };
            return model.IsValid();
        }

        [TestCase("testStaticValue", ExpectedResult = true)]
        [TestCase("otherValue", ExpectedResult = false)]
        public bool WithStaticValueTest(string value)
        {
            var model = new ModelWithStaticValue { Value = value };
            return model.IsValid();
        }

        [TestCase(null, null, ExpectedResult = true)]
        [TestCase(null, "hello", ExpectedResult = true)]
        [TestCase("hello", null, ExpectedResult = true)]
        public bool WithPassOnNullTest(string value1, string value2)
        {
            var model = new ModelWithPassOnNull { Value1 = value1, Value2 = value2 };
            return model.IsValid();
        }

        private class Model
        {
            public string Value1 { get; set; }

            [Is(EqualTo, Property = nameof(Value1))]
            public string Value2 { get; set; }
        }

        private class ModelWithStaticValue
        {
            [Is(EqualTo, Value = "testStaticValue")]
            public string Value { get; set; }
        }

        private class ModelWithPassOnNull
        {
            public string Value1 { get; set; }

            [Is(EqualTo, Property = nameof(Value1), PassOnNull = true)]
            public string Value2 { get; set; }
        }
    }
}
