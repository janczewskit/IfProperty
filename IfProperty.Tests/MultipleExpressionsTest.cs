using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using static IfProperty.IsOperatorEnumeration;

namespace IfProperty.Tests
{
	[TestFixture]
    public class MultipleExpressionsTest
    {
        [TestCase("test", "test", ExpectedResult = false)]
        [TestCase("LongPassword", "LongPassword", ExpectedResult = false)]
        [TestCase("LongPassword1", "LongPassword2", ExpectedResult = false)]
        [TestCase("LongPassword333", "LongPassword333", ExpectedResult = true)]
        public bool AddCustomPropertyExpressionTest(string password, string repeatedPassword)
        {
            var model = new Model { Password = password, RepeatedPassword = repeatedPassword };
            return model.IsValid();
        }

        private class Model
        {
            [Required]
            [Is(RegExMatch, Value = @"\w{5}", CustomMessage = "Minimum 5 characters")]
            [Is(RegExMatch, Value = @".*[0-9].*", CustomMessage = "At least one number")]
            public string Password { get; set; }

            [Required]
            [Is(EqualTo, Property = nameof(Password))]
            public string RepeatedPassword { get; set; }
        }
    }
}
