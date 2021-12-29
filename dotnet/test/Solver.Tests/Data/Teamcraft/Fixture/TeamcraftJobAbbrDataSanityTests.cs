using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WuphonsReach.FF14Crafting.Solver.Tests.Data.Teamcraft.Fixture
{
    /// <summary>Make assertions about the Teamcraft JobAbbr JSON data that we
    /// require to be true.  This will help spot mismatches between the JSON
    /// that we designed for and a later version of the JSON files.
    /// </summary>
    [Collection(nameof(TeamcraftDataRepositoryCollection))]
    public class TeamcraftJobAbbrDataSanityTests
    {
        private readonly TeamcraftDataRepositoryFixture _fixture;

        public TeamcraftJobAbbrDataSanityTests(
            TeamcraftDataRepositoryFixture fixture
            )
        {
            _fixture = fixture;
        }

        [Fact]
        public void Items_Count_is_not_zero()
        {
            var db = _fixture.GetRepository();
            Assert.NotEqual(0, db.JobAbbrs.Value.Count);
        }
        
        [Fact]
        public void There_are_no_repeated_English_names()
        {
            var db = _fixture.GetRepository();
            var names = db.JobAbbrs.Value.Values
                .Select(x => x.English);
            AssertNoDuplicates(names);
        }

        [Fact]
        public void There_are_no_repeated_Japanese_names()
        {
            var db = _fixture.GetRepository();
            var names = db.JobAbbrs.Value.Values
                .Select(x => x.Japanese);
            AssertNoDuplicates(names);
        }

        [Fact]
        public void There_are_no_repeated_German_names()
        {
            var db = _fixture.GetRepository();
            var names = db.JobAbbrs.Value.Values
                .Select(x => x.German);
            AssertNoDuplicates(names);
        }

        [Fact]
        public void There_are_no_repeated_French_names()
        {
            var db = _fixture.GetRepository();
            var names = db.JobAbbrs.Value.Values
                .Select(x => x.French);
            AssertNoDuplicates(names);
        }

        private static void AssertNoDuplicates(IEnumerable<string> names)
        {
            var result = names
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .GroupBy(x => x)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key);
            Assert.Empty(result);
        }
        
        /// <summary>The current assumption is that all en/ja values in job-abbr.json
        /// match.  And that we can use the English abbreviations in job-categories.json
        /// to get the list of DoH job IDs.  If they stop matching, we need to figure
        /// out if job-categories.json is using English or Japanese for the jobs list.</summary>
        [Fact]
        public void All_English_and_Japanese_abbreviations_match()
        {
            var db = _fixture.GetRepository();
            var names = db.JobAbbrs.Value.Values
                .Where(x => x.English != x.Japanese);
            Assert.Empty(names);
        }
    }
}