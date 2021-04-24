using IfProperty.RequiredExtensions;
using NUnit.Framework;

namespace IfProperty.Tests.RequiredExpressions
{
	[TestFixture]
    public class RequiredIfNotNullTest
    {
        [TestCase(null, null, ExpectedResult = true)]
        [TestCase(1, null, ExpectedResult = false)]
        [TestCase(null, 1, ExpectedResult = false)]
        [TestCase(1, 1, ExpectedResult = true)]
        public bool Test(int? min, int? max)
        {
            var model = new Model { Min = min, Max = max };
            return model.IsValid();
        }

        private class Model
        {
            [RequiredIfNotNull(nameof(Max))]
            public int? Min { get; set; }

            [RequiredIfNotNull(nameof(Min))]
            public int? Max { get; set; }
        }
    }
}
