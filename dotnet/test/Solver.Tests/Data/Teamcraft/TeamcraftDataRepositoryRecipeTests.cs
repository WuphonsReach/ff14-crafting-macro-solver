using WuphonsReach.FF14Crafting.Solver.Tests.Data.Teamcraft.Fixture;
using Xunit;

namespace WuphonsReach.FF14Crafting.Solver.Tests.Data.Teamcraft
{
    /// <summary>Test any public Recipe...() methods.</summary>
    [Collection(nameof(TeamcraftDataRepositoryCollection))]
    public class TeamcraftDataRepositoryPublicRecipeTests
    {
        private readonly TeamcraftDataRepositoryFixture _fixture;

        public TeamcraftDataRepositoryPublicRecipeTests(
            TeamcraftDataRepositoryFixture fixture
            )
        {
            _fixture = fixture;
        }
    }
}