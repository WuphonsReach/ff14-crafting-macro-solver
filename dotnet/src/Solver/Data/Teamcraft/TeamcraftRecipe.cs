using Newtonsoft.Json;

namespace WuphonsReach.FF14Crafting.Solver.Data.Teamcraft
{
    public class TeamcraftRecipe
    {
        /// <summary>The ID values are usually, but not always, integers.</summary>
        public string Id { get; set; }

        /// <summary>JobId can be zero, if the recipe is not for a crafting job.</summary>
        [JsonProperty("job")]
        public int JobId { get; set; }

        [JsonProperty("lvl")]
        public int Level { get; set; }
        
        public int Yields { get; set; }
        
        /// <summary>Item ID of the result.  See <see cref="TeamcraftItems"/> dictionary
        /// keys to obtain the item name from the <see cref="TeamcraftItem"/>.</summary>
        [JsonProperty("result")]
        public int ResultId { get; set; }
 
        
    }
}