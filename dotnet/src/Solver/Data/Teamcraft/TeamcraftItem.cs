using Newtonsoft.Json;

namespace WuphonsReach.FF14Crafting.Solver.Data.Teamcraft
{
    public class TeamcraftItem
    {
        [JsonProperty("en")]
        public string English { get; set; }
        [JsonProperty("de")]
        public string German { get; set; }
        [JsonProperty("ja")]
        public string Japanese { get; set; }
        [JsonProperty("fr")]
        public string French { get; set; }
        
        public string Name()
        {
            // later, this method will take a locale argument

            // Not all item IDs have a name defined (unused item IDs)
            return string.IsNullOrWhiteSpace(English)
                ? "(no name)"
                : English;
        }
    }
}