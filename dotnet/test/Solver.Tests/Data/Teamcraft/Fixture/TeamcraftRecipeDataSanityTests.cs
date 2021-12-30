using System;
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
        
        /// <summary>We have at least one recipe in the list.</summary>
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
        public void There_are_any_JobId_values_greater_than_zero()
        {
            var db = _fixture.GetRepository();
            Assert.Contains(db.Recipes.Value, x => x.JobId > 0);
        }
        
        [Fact]
        public void All_JobId_greater_than_zero_map_to_a_JobName()
        {
            var db = _fixture.GetRepository();
            foreach (var recipe in db.Recipes.Value.Where(x => x.JobId is > 0))
            {
                var id = recipe.JobId ?? throw new Exception("Something is wrong");
                var item = db.JobNameById(id);
                Assert.True(
                    item != null,
                    $"ID {recipe.Id}: {nameof(recipe.JobId)} {recipe.JobId} is not a valid JobName ID."
                );
            }
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
        public void There_are_any_Level_values_greater_than_zero()
        {
            var db = _fixture.GetRepository();
            Assert.Contains(db.Recipes.Value, x => x.Level > 0);
        }
        
        [Fact]
        public void All_ResultId_greater_than_zero_and_valid_JobID_map_to_an_item()
        {
            var db = _fixture.GetRepository();
            foreach (var recipe in db.Recipes.Value
                         .Where(x => 
                             x.ResultId is > 0 
                             && x.JobId is > 0
                        ))
            {
                var id = recipe.JobId ?? throw new Exception("Something is wrong");
                var item = db.ItemById(id);
                Assert.True(
                    item != null,
                    $"ID {recipe.Id}: {nameof(recipe.ResultId)} {recipe.ResultId} is not a valid Item ID."
                );
            }
        }
        
        [Fact]
        public void There_are_any_ResultId_values_greater_than_zero()
        {
            var db = _fixture.GetRepository();
            Assert.Contains(db.Recipes.Value, x => x.ResultId > 0);
        }
        
        [Fact]
        public void There_are_any_Quality_values_greater_than_zero()
        {
            var db = _fixture.GetRepository();
            Assert.Contains(db.Recipes.Value, x => x.Quality > 0);
        }
        
        [Fact]
        public void There_are_any_Durability_values_greater_than_zero()
        {
            var db = _fixture.GetRepository();
            Assert.Contains(db.Recipes.Value, x => x.Durability > 0);
        }
        
        [Fact]
        public void There_are_any_Progress_values_greater_than_zero()
        {
            var db = _fixture.GetRepository();
            Assert.Contains(db.Recipes.Value, x => x.Progress > 0);
        }
    }
}