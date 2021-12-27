using Xunit;

namespace Data.Tests
{
    public class MaterialConditionsTests
    {
        private readonly MaterialConditions _sut = new MaterialConditions();

        [Fact]
        public void All_is_not_empty()
        {
            Assert.NotEmpty(_sut.All.Value);
        }
    }
}