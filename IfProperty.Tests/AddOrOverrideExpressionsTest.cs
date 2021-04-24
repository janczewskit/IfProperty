using IfProperty.Expressions;
using NUnit.Framework;
using static IfProperty.IsOperatorEnumeration;

namespace IfProperty.Tests
{
	[TestFixture]
    public class AddOrOverrideExpressionsTest
    {
        [Test]
        public void AddCustomPropertyExpressionTest()
        {
            IfPropertyExpressionsContainer.AddOrOverride("invalid", new CustomInvalidPropertyExpression());
            var model = new CustomExpressionModel { Value = "Test"};
            Assert.IsFalse(model.IsValid());
        }

        [Test]
        public void OverrideExistingPropertyIfNotValidYetExpressionTest()
        {
            IfPropertyExpressionsContainer.AddOrOverride(EqualTo, new CustomInvalidPropertyExpression());
            var model = new NotEvaluatedModel { Value = "Test" };
            Assert.IsFalse(model.IsValid());

            IfPropertyExpressionsContainer.Clear();
            Assert.IsFalse(model.IsValid());
        }

        [Test]
        public void NotOverrideExistingPropertyExpressionAfterCreateObjectTest()
        {
            var model = new Model { Value = "Test" };
            Assert.IsTrue(model.IsValid());

            IfPropertyExpressionsContainer.AddOrOverride(EqualTo, new CustomInvalidPropertyExpression());
            Assert.IsTrue(model.IsValid());
        }

        [TearDown]
        public void TearDown()
        {
            IfPropertyExpressionsContainer.Clear();
        }

        private class CustomInvalidPropertyExpression : IIfPropertyExpression
        {
            public string ErrorMessage => "invalid";

            public bool IsValid(object value, object dependentValue)
            {
                return false;
            }
        }

        private class CustomExpressionModel
        {
            [Is("invalid", Property = nameof(Value))]
            public string Value { get; set; }
        }

        private class Model
        {
            [Is(EqualTo, Property = nameof(Value))]
            public string Value { get; set; }
        }

        private class NotEvaluatedModel
        {
            [Is(EqualTo, Property = nameof(Value))]
            public string Value { get; set; }
        }
    }
}
