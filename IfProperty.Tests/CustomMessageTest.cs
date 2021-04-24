using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using static IfProperty.IsOperatorEnumeration;

namespace IfProperty.Tests
{
	[TestFixture]
    public class CustomMessageTest
    {
        private const string CustomMessage = "At least one number";

        [Test]
        public void AddCustomPropertyExpressionTest()
        {
            var model = new Model { Password = "test" };

            var validationResults = new List<ValidationResult>();
            Assert.IsFalse(model.IsValid(validationResults));
            Assert.AreEqual(CustomMessage, validationResults.Single().ErrorMessage);
        }

        private class Model
        {
            [Is(RegExMatch, Value = @".*[0-9].*", CustomMessage = CustomMessage)]
            public string Password { get; set; }
        }
    }
}
