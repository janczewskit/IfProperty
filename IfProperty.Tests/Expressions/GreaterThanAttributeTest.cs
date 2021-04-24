using NUnit.Framework;
using static IfProperty.IsOperatorEnumeration;

namespace IfProperty.Tests.Expressions
{
    [TestFixture]
    public class GreaterThanAttributeTest
    {
        [TestCase(1, 2, ExpectedResult = true)]
        [TestCase(1, -1, ExpectedResult = false)]
        [TestCase(null, null, ExpectedResult = false)]
        [TestCase(1, null, ExpectedResult = false)]
        [TestCase(null, 1, ExpectedResult = false)]
        public bool Test(int? value1, int? value2)
        {
            var model = new Model { Value1 = value1, Value2 = value2 };
            return model.IsValid();
        }

        [TestCase(1, null, ExpectedResult = true)]
        [TestCase(null, 1, ExpectedResult = true)]
        public bool WithPassOnNullTest(int? value1, int? value2)
        {
            var model = new ModelWithPassOnNull { Value1 = value1, Value2 = value2 };
            return model.IsValid();
        }

        [TestCase(1, 2, ExpectedResult = true)]
        [TestCase(1, -1, ExpectedResult = false)]
        [TestCase(1, 1, ExpectedResult = true)]
        [TestCase(null, null, ExpectedResult = true)]
        [TestCase(1, null, ExpectedResult = false)]
        [TestCase(null, 1, ExpectedResult = false)]
        public bool OrEqualTest(int? value1, int? value2)
        {
            var model = new ModelOrEqual { Value1 = value1, Value2 = value2 };
            return model.IsValid();
        }

        [TestCase(1, null, ExpectedResult = true)]
        [TestCase(null, 1, ExpectedResult = true)]
        [TestCase(1, 1, ExpectedResult = true)]
        public bool OrEqualWithPassOnNullTest(int? value1, int? value2)
        {
            var model = new ModelOrEqualThanWithPassOnNull { Value1 = value1, Value2 = value2 };
            return model.IsValid();
        }

        [TestCase(2, ExpectedResult = true)]
        [TestCase(1, ExpectedResult = false)]
        public bool WithStaticValueTest(int? value)
        {
            var model = new ModelWithStaticValue { Value = value };
            return model.IsValid();
        }

        [TestCase(2, ExpectedResult = true)]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(0, ExpectedResult = false)]
        public bool ModelOrEqualWithStaticValueTest(int? value)
        {
            var model = new ModelOrEqualWithStaticValue { Value = value };
            return model.IsValid();
        }

        private class Model
        {
            public int? Value1 { get; set; }

            [Is(GreaterThan, Property = nameof(Value1))]
            public int? Value2 { get; set; }
        }

        private class ModelWithStaticValue
        {
            [Is(GreaterThan, Value = 1)]
            public int? Value { get; set; }
        }

        private class ModelWithPassOnNull
        {
            public int? Value1 { get; set; }

            [Is(GreaterThan, Property = nameof(Value1), PassOnNull= true)]
            public int? Value2 { get; set; }
        }

        private class ModelOrEqual
        {
            public int? Value1 { get; set; }

            [Is(GreaterThanOrEqualTo, Property = nameof(Value1))]
            public int? Value2 { get; set; }
        }

        private class ModelOrEqualWithStaticValue
        {
            [Is(GreaterThanOrEqualTo, Value = 1)]
            public int? Value { get; set; }
        }

        private class ModelOrEqualThanWithPassOnNull
        {
            public int? Value1 { get; set; }

            [Is(GreaterThanOrEqualTo, Property = nameof(Value1), PassOnNull = true)]
            public int? Value2 { get; set; }
        }
    }
}
