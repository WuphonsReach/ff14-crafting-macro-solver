using Newtonsoft.Json;

namespace WuphonsReach.FF14Crafting.Solver.Data.Teamcraft
{
    public class TeamcraftItem : IHasTeamcraftLanguages
    {
        [JsonProperty("en")]
        public string English { get; set; }
        [JsonProperty("de")]
        public string German { get; set; }
        [JsonProperty("ja")]
        public string Japanese { get; set; }
        [JsonProperty("fr")]
        public string French { get; set; }
    }
}