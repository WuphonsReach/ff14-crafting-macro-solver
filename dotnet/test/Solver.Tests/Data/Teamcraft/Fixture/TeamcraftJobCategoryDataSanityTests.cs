using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WuphonsReach.FF14Crafting.Solver.Tests.Data.Teamcraft.Fixture
{
    /// <summary>Make assertions about the Teamcraft Job Category JSON data that we
    /// require to be true.  This will help spot mismatches between the JSON
    /// that we designed for and a later version of the JSON files.
    /// </summary>
    [Collection(nameof(TeamcraftDataRepositoryCollection))]
    public class TeamcraftJobCategoryDataSanityTests
    {
        private readonly TeamcraftDataRepositoryFixture _fixture;

        public TeamcraftJobCategoryDataSanityTests(
            TeamcraftDataRepositoryFixture fixture
            )
        {
            _fixture = fixture;
        }

        [Fact]
        public void Items_Count_is_not_zero()
        {
            var db = _fixture.GetRepository();
            Assert.NotEqual(0, db.JobCategories.Value.Count);
        }

        [Fact]
        public void JobAbbreviationsForDiscipleOfTheHandCategory_returns_something()
        {
            var db = _fixture.GetRepository();
            var results = db.JobAbbreviationsForDiscipleOfTheHandCategory().ToList();
            Assert.NotEmpty(results);
        }
        
        [Fact]
        public void JobAbbreviationsForDiscipleOfTheHandCategory_returns_no_duplicates()
        {
            var db = _fixture.GetRepository();
            var results = db.JobAbbreviationsForDiscipleOfTheHandCategory().ToList();
            AssertNoDuplicates(results);
        }
        
        private static void AssertNoDuplicates(IEnumerable<string> names)
        {
            var result = names
                .GroupBy(x => x)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key);
            Assert.Empty(result);
        }
        
        [Fact]
        public void JobAbbreviationsForDiscipleOfTheHandCategory_returns_valid_abbreviations()
        {
            var db = _fixture.GetRepository();
            var results = db.JobAbbreviationsForDiscipleOfTheHandCategory()
                .Where(x => db.JobAbbrByAbbreviation(x) is null);
            Assert.Empty(results);
        }
    }
}