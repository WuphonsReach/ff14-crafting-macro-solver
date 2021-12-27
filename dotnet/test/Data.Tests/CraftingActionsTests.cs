using System.Linq;
using Xunit;

namespace Data.Tests
{
    public class CraftingActionsTests
    {
        private readonly CraftingActions _sut = new CraftingActions();
        private readonly MaterialConditions _materialConditions = new MaterialConditions();

        private const int MaximumCraftingPoints = 999;

        [Fact]
        public void All_is_not_empty()
        {
            Assert.NotEmpty(_sut.All.Value);
        }

        //TODO: Consider adding DataAnnotation or FluentValidation
        
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
        public void CP_is_value_0_to_MaximumCraftingPoints()
        {
            var result = _sut.All.Value
                .Where(x => !(x.Value.CP >= 0 && x.Value.CP <= MaximumCraftingPoints))
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
        
        [Fact]
        public void WhenCombo_Action_is_valid()
        {
            var actions = _sut.All.Value
                .Where(x => x.Value
                .WhenCombo?.Any() == true).ToList();

            foreach (var action in actions)
            {
                var values = action.Value.WhenCombo.Select(y => y.Action).ToList();
                foreach (var value in values)
                {
                    Assert.True(
                        _sut.All.Value.Keys.Contains(value), 
                        $"Action ({action.Key}): Value '{value}' not valid {nameof(WhenComboAction.Action)} in {nameof(action.Value.WhenCombo)} list."
                    );
                }
            }
        }
        
        [Fact]
        public void WhenCombo_CP_is_valid()
        {
            var actions = _sut.All.Value
                .Where(x => x.Value
                    .WhenCombo?.Any() == true).ToList();

            foreach (var action in actions)
            {
                var values = action.Value.WhenCombo
                    .Where(x => x.CP.HasValue)
                    .ToList();
                foreach (var value in values)
                {
                    Assert.True(
                        value.CP >= 0 && value.CP <= MaximumCraftingPoints, 
                        $"Action ({action.Key}): Value '{value.CP}' not valid {nameof(WhenComboAction.CP)} in {nameof(action.Value.WhenCombo)} list."
                    );
                }
            }
        }
    }
}