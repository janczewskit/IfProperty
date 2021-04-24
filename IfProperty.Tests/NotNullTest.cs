using NUnit.Framework;
using static IfProperty.IsOperatorEnumeration;

namespace IfProperty.Tests
{
	[TestFixture]
    public class NotNullTest
    {
        [TestCase]
        public void Test()
        {
            var model = new Model { Password = null };
            Assert.IsFalse(model.IsValid());

            model.Password = "pass";
            Assert.IsTrue(model.IsValid());
        }

        private class Model
        {
            [Is(NotEqualTo, Value = null)]
            public string Password { get; set; }
        }
    }
}
