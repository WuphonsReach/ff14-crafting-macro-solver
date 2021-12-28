using WuphonsReach.FF14Crafting.Solver.Tests.Data.Teamcraft.Fixture;
using Xunit;

namespace WuphonsReach.FF14Crafting.Solver.Tests.Data.Teamcraft
{
    /// <summary>Test any public Item...() methods.</summary>
    [Collection(nameof(TeamcraftDataRepositoryCollection))]
    public class TeamcraftDataRepositoryPublicItemsTests
    {
        private readonly TeamcraftDataRepositoryFixture _fixture;

        public TeamcraftDataRepositoryPublicItemsTests(
            TeamcraftDataRepositoryFixture fixture
            )
        {
            _fixture = fixture;
        }
    }
}