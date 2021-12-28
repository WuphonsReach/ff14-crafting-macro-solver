using Xunit;

namespace WuphonsReach.FF14Crafting.Solver.Tests.Data.Teamcraft.Fixture
{
    [CollectionDefinition(nameof(TeamcraftDataRepositoryCollection))]
    public class TeamcraftDataRepositoryCollection 
        : ICollectionFixture<TeamcraftDataRepositoryFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}