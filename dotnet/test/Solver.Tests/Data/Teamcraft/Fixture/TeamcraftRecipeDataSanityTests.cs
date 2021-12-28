using System.Linq;
using Xunit;

namespace WuphonsReach.FF14Crafting.Solver.Tests.Data.Teamcraft.Fixture
{
    /// <summary>Make assertions about the Teamcraft Recipe JSON data that we
    /// require to be true.  This will help spot mismatches between the JSON
    /// that we designed for and a later version of the JSON files.
    /// </summary>
    [Collection(nameof(TeamcraftDataRepositoryCollection))]
    public class TeamcraftRecipeDataSanityTests
    {
        private readonly TeamcraftDataRepositoryFixture _fixture;

        public TeamcraftRecipeDataSanityTests(
            TeamcraftDataRepositoryFixture fixture
            )
        {
            _fixture = fixture;
        }
        
        [Fact]
        public void Recipes_Count_is_not_zero()
        {
            var db = _fixture.GetRepository();
            Assert.NotEqual(0, db.Recipes.Value.Count);
        }
        
        [Fact]
        public void Id_is_not_null_empty_string()
        {
            var db = _fixture.GetRepository();
            foreach (var recipe in db.Recipes.Value)
            {
                Assert.True(
                    !string.IsNullOrWhiteSpace(recipe.Id),
                    $"ID {recipe.Id}: {nameof(recipe.Id)} is not > 0."
                );
            }
        }
        
        [Fact]
        public void All_JobId_values_are_greater_equal_to_zero()
        {
            var db = _fixture.GetRepository();
            foreach (var recipe in db.Recipes.Value)
            {
                Assert.True(
                    recipe.JobId >= 0,
                    $"ID {recipe.Id}: {nameof(recipe.JobId)} {recipe.JobId} is not >= 0."
                );
            }
        }
        
        [Fact]
        public void There_are_JobId_values_greater_than_zero()
        {
            var db = _fixture.GetRepository();
            var result = db.Recipes.Value.Count(x => x.JobId > 0);
            Assert.NotEqual(0, result);
        }
        
        [Fact]
        public void All_Level_values_are_greater_than_zero()
        {
            var db = _fixture.GetRepository();
            foreach (var recipe in db.Recipes.Value)
            {
                Assert.True(
                    recipe.Level > 0,
                    $"ID {recipe.Id}: {nameof(recipe.Level)} {recipe.Level} is not > 0."
                );
            }
        }
        
        [Fact]
        public void There_are_Level_values_greater_than_zero()
        {
            var db = _fixture.GetRepository();
            var result = db.Recipes.Value.Count(x => x.Level > 0);
            Assert.NotEqual(0, result);
        }
    }
}