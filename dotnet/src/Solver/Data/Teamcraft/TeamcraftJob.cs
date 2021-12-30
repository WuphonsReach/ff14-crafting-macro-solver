using System;

namespace WuphonsReach.FF14Crafting.Solver.Data.Teamcraft
{
    /// <summary>Pulls together JobId, names and abbreviations into a single object.</summary>
    public class TeamcraftJob
    {
        public TeamcraftJob(
            TeamcraftJobName teamcraftJobName,
            TeamcraftJobAbbr teamcraftJobAbbr
            )
        {
            var jobNameId = teamcraftJobName.Id;
            var jobAbbrId = teamcraftJobAbbr.Id;
            if (jobNameId != jobAbbrId)
                throw new Exception(
                    $"ID mismatch: {jobNameId} != {jobAbbrId}"
                    );

            Id = jobNameId;
            Name = teamcraftJobName;
            Abbreviation = teamcraftJobAbbr;
        }
        
        public int Id { get; }
        public TeamcraftJobName Name { get; }
        public TeamcraftJobAbbr Abbreviation { get; }
    }
}