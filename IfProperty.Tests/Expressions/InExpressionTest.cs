using NUnit.Framework;
using static IfProperty.IsOperatorEnumeration;

namespace IfProperty.Tests.Expressions
{
	[TestFixture]
    public class InExpressionTest
    {
        [TestCase(new [] {"hello"}, "hello", ExpectedResult = true)]
        [TestCase(new [] {"hello"}, "goodbye", ExpectedResult = false)]
        [TestCase(null, null, ExpectedResult = true)]
        [TestCase(null, "hello", ExpectedResult = false)]
        [TestCase(new[] { "hello" }, null, ExpectedResult = false)]
        public bool Test(string[] value1, string value2)
        {
            var model = new Model { Value1 = value1, Value2 = value2 };
            return model.IsValid();
        }

        [TestCase("testStaticValue", ExpectedResult = true)]
        [TestCase("testStaticValue2", ExpectedResult = true)]
        [TestCase("testStaticValue3", ExpectedResult = false)]
        public bool WithStaticValueTest(string value)
        {
            var model = new ModelWithStaticValue { Value = value };
            return model.IsValid();
        }

        [TestCase(null, null, ExpectedResult = true)]
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

            [Is(In, Property = nameof(Value1))]
            public string Value2 { get; set; }
        }

        private class ModelWithStaticValue
        {
            [Is(In, Value = new [] {"testStaticValue", "testStaticValue2" })]
            public string Value { get; set; }
        }

        private class ModelWithPassOnNull
        {
            public string[] Value1 { get; set; }

            [Is(In, Property = nameof(Value1), PassOnNull = true)]
            public string Value2 { get; set; }
        }
    }
}
