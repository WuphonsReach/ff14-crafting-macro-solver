using System.Collections.Generic;
using Newtonsoft.Json;

namespace WuphonsReach.FF14Crafting.Solver.Data.Teamcraft
{
    public class TeamcraftJobCategory : IHasTeamcraftLanguages
    {
        /// <summary>English name for the job category for DoH list of job abbreviations.</summary>
        public const string DiscipleOfTheHand = "Disciple of the Hand"; 
        
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("en")]
        public string English { get; set; }
        [JsonProperty("de")]
        public string German { get; set; }
        [JsonProperty("ja")]
        public string Japanese { get; set; }
        [JsonProperty("fr")]
        public string French { get; set; }
        
        /// <summary>It's unclear at the moment whether this list of abbreviations
        /// for the job names matches up with the English or Japanese property on
        /// a <see cref="TeamcraftJobAbbr"/>.  At the moment, the two values are
        /// always identical.
        /// </summary>
        [JsonProperty("jobs")]
        public List<string> JobAbbreviations { get; set; }
    }
}