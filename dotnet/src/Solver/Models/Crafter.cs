using System.Collections.Generic;

namespace WuphonsReach.FF14Crafting.Solver.Models
{
    /// <summary>Stats for the crafter.</summary>
    public class Crafter
    {
        public int CraftingPoints { get; set; }
        public int Control { get; set; }
        public int Craftsmanship { get; set; }
        public int Level { get; set; }
        
        /// <summary>Which actions the crafter wants to use.</summary>
        public List<string> ActiveActions { get; set; }
    }
}