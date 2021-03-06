using Xunit;

namespace WuphonsReach.FF14Crafting.Solver.Tests.Data.Teamcraft.Fixture
{
    /// <summary>Make assertions about the Teamcraft CraftActions JSON data that we
    /// require to be true.  This will help spot mismatches between the JSON
    /// that we designed for and a later version of the JSON files.
    /// </summary>
    [Collection(nameof(TeamcraftDataRepositoryCollection))]
    public class TeamcraftCraftActionDataSanityTests
    {
        private readonly TeamcraftDataRepositoryFixture _fixture;

        public TeamcraftCraftActionDataSanityTests(
            TeamcraftDataRepositoryFixture fixture
            )
        {
            _fixture = fixture;
        }

        [Fact]
        public void CraftActions_Count_is_not_zero()
        {
            var db = _fixture.GetRepository();
            Assert.NotEqual(0, db.CraftActions.Value.Count);
        }
    }
}