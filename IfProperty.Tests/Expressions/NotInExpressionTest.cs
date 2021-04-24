using NUnit.Framework;
using static IfProperty.IsOperatorEnumeration;

namespace IfProperty.Tests.Expressions
{
	[TestFixture]
    public class NotInExpressionTest
    {
        [TestCase(new [] {"hello"}, "hello", ExpectedResult = false)]
        [TestCase(new [] {"hello"}, "goodbye", ExpectedResult = true)]
        [TestCase(null, null, ExpectedResult = false)]
        [TestCase(null, "hello", ExpectedResult = true)]
        [TestCase(new[] { "hello" }, null, ExpectedResult = true)]
        public bool Test(string[] value1, string value2)
        {
            var model = new Model { Value1 = value1, Value2 = value2 };
            return model.IsValid();
        }

        [TestCase("testStaticValue", ExpectedResult = false)]
        [TestCase("testStaticValue2", ExpectedResult = false)]
        [TestCase("testStaticValue3", ExpectedResult = true)]
        public bool WithStaticValueTest(string value)
        {
            var model = new ModelWithStaticValue { Value = value };
            return model.IsValid();
        }

        [TestCase(null, null, ExpectedResult = false)]
        [TestCase(null, "hello", ExpectedResult = true)]
        [TestCase(new [] {"hello"}, null, ExpectedResult = true)]
        public bool WithPassOnNullTest(string[] value1, string value2)
        {
            var model = new ModelWithPassOnNull { Value1 = value1, Value2 = value2 };
            return model.IsValid();
        }

        private class Model
        {
            public string[] Value1 { get; set; }

            [Is(NotIn, Property = nameof(Value1))]
            public string Value2 { get; set; }
        }

        private class ModelWithStaticValue
        {
            [Is(NotIn, Value = new [] {"testStaticValue", "testStaticValue2" })]
            public string Value { get; set; }
        }

        private class ModelWithPassOnNull
        {
            public string[] Value1 { get; set; }

            [Is(NotIn, Property = nameof(Value1), PassOnNull = true)]
            public string Value2 { get; set; }
        }
    }
}
