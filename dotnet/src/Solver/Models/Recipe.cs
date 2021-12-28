namespace WuphonsReach.FF14Crafting.Solver.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public int Durability { get; set; }
        
        /// <summary>Difficulty is directly related to the number of progress
        /// points needed to reach 100% progress.</summary>
        public int Difficulty { get; set; }

        /// <summary>This is the amount of quality points needed to reach a 100%
        /// guaranteed HQ result.  It is displayed in-game on the recipe page.
        /// </summary>
        public int Quality { get; set; }
        
        public int Level { get; set; }
    }
}