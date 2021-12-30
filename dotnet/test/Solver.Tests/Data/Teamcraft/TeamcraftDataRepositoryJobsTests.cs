using WuphonsReach.FF14Crafting.Solver.Tests.Data.Teamcraft.Fixture;
using Xunit;

namespace WuphonsReach.FF14Crafting.Solver.Tests.Data.Teamcraft
{
    /// <summary>Test any public Job...() methods.</summary>
    [Collection(nameof(TeamcraftDataRepositoryCollection))]
    public class TeamcraftDataRepositoryPublicJobsTests
    {
        private readonly TeamcraftDataRepositoryFixture _fixture;

        public TeamcraftDataRepositoryPublicJobsTests(
            TeamcraftDataRepositoryFixture fixture
            )
        {
            _fixture = fixture;
        }
        
        [Fact]
        public void Jobs_Count_is_not_zero()
        {
            var db = _fixture.GetRepository();
            Assert.NotEqual(0, db.Jobs.Value.Count);
        }
        
        [Fact]
        public void All_JobAbbr_IDs_are_present_in_Jobs()
        {
            var db = _fixture.GetRepository();
            var jobIds = db.Jobs.Value.Keys;
            var ids = db.JobAbbrs.Value.Keys;
            Assert.Equal(ids.Count, jobIds.Count);
            foreach (var id in ids)
            {
                Assert.NotNull(db.JobById(id));
            }
        }
        
        [Fact]
        public void All_JobName_IDs_are_present_in_Jobs()
        {
            var db = _fixture.GetRepository();
            var jobIds = db.Jobs.Value.Keys;
            var ids = db.JobNames.Value.Keys;
            Assert.Equal(ids.Count, jobIds.Count);
            foreach (var id in ids)
            {
                Assert.NotNull(db.JobById(id));
            }
        }
    }
}