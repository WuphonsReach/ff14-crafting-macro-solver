using Newtonsoft.Json;

namespace WuphonsReach.FF14Crafting.Solver.Data.Teamcraft
{
    public class TeamcraftRecipe
    {
        /// <summary>The ID values are usually, but not always, integers.</summary>
        public string Id { get; set; }

        /// <summary>JobId can be zero, if the recipe is not for a crafting job.</summary>
        [JsonProperty("job")]
        public int? JobId { get; set; }

        [JsonProperty("lvl")]
        public int? Level { get; set; }
        
        public int? Yields { get; set; }
        
        /// <summary>Item ID of the result.</summary>
        [JsonProperty("result")]
        public int? ResultId { get; set; }

        [JsonProperty("durability")]
        public int? Durability { get; set; }
        
        [JsonProperty("quality")]
        public int? Quality { get; set; }
        
        [JsonProperty("progress")]
        public int? Progress { get; set; }
    }
}