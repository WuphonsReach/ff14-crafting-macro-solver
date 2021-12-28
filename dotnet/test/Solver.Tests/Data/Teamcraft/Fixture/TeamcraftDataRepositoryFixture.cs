using WuphonsReach.FF14Crafting.Solver.Data.Teamcraft;

namespace WuphonsReach.FF14Crafting.Solver.Tests.Data.Teamcraft.Fixture
{
    public class TeamcraftDataRepositoryFixture
    {
        private static readonly TeamcraftDataRepository Repository = new();
        public TeamcraftDataRepository GetRepository() => Repository;
    }
}