using System.Linq;
using WuphonsReach.FF14Crafting.Solver.Data;
using Xunit;

namespace WuphonsReach.FF14CraftingMacroSolver.Models.Tests.Data
{
    public class MaterialConditionsTests
    {
        private readonly MaterialConditions _sut = new MaterialConditions();

        [Fact]
        public void All_is_not_empty()
        {
            Assert.NotEmpty(_sut.All.Value);
        }
        
        [Fact]
        public void Name_is_provided()
        {
            var result = _sut.All.Value
                .Where(x => string.IsNullOrWhiteSpace(x.Value.Name))
                .ToList();
            Assert.Empty(result);
        }
    }
}