using Xunit;

namespace Data.Tests
{
    public class CraftingActionsTests
    {
        private readonly CraftingActions _sut = new CraftingActions();

        [Fact]
        public void All_is_not_empty()
        {
            Assert.NotEmpty(_sut.All.Value);
        }
    }
}