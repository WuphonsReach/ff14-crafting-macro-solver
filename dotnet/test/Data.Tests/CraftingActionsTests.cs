using System.Linq;
using Xunit;

namespace Data.Tests
{
    public class CraftingActionsTests
    {
        private readonly CraftingActions _sut = new CraftingActions();
        private readonly MaterialConditions _materialConditions = new MaterialConditions();

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

        [Fact]
        public void Description_is_provided()
        {
            var result = _sut.All.Value
                .Where(x => string.IsNullOrWhiteSpace(x.Value.Description))
                .ToList();
            Assert.Empty(result);
        }

        [Fact]
        public void Level_is_value_1_to_90()
        {
            var result = _sut.All.Value
                .Where(x => !(x.Value.Level >= 1 && x.Value.Level <= 90))
                .ToList();
            Assert.Empty(result);
        }

        [Fact]
        public void CP_is_value_0_to_999()
        {
            var result = _sut.All.Value
                .Where(x => !(x.Value.CP >= 0 && x.Value.CP <= 999))
                .ToList();
            Assert.Empty(result);
        }

        [Fact]
        public void WhenMaterialCondition_values_are_correct()
        {
            var actions = _sut.All.Value;
            var actionsWithMaterialCondition =
                actions.Where(x => x.Value
                    .WhenMaterialCondition?.Any() == true).ToList();

            foreach (var action in actionsWithMaterialCondition)
            {
                var key = action.Key;
                var values = action.Value.WhenMaterialCondition;
                foreach (var value in values)
                {
                    Assert.True(
                        _materialConditions.All.Value.Keys.Contains(value), 
                        $"Action ({action.Key}): Value '{value}' not valid in {nameof(action.Value.WhenMaterialCondition)} list."
                        );
                }
            }
        }
    }
}