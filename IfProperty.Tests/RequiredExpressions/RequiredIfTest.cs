using IfProperty.RequiredExtensions;
using NUnit.Framework;

namespace IfProperty.Tests.RequiredExpressions
{
	[TestFixture]
    public class RequiredIfTest
    {
        [TestCase(null, null, ExpectedResult = false)]
        [TestCase(1, null, ExpectedResult = true)]
        [TestCase(null, 1, ExpectedResult = true)]
        [TestCase(1, 1, ExpectedResult = true)]
        public bool Test(int? pagesToSkip, int? pageContainsId)
        {
            var model = new Model { PagesToSkip = pagesToSkip, PageContainsId = pageContainsId };
            return model.IsValid();
        }

        private class Model
        {
            [RequiredIf(nameof(PageContainsId), null)]
            public int? PagesToSkip { get; set; }

            [RequiredIf(nameof(PagesToSkip), null)]
            public int? PageContainsId { get; set; }
        }
    }
}
