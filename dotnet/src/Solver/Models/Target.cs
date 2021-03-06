namespace WuphonsReach.FF14Crafting.Solver.Models
{
    public class Target
    {
        public Target(Crafter crafter, Recipe recipe)
        {
            CraftingPoints = crafter.CraftingPoints;
            Durability = recipe.Durability;
            Progress = CalculateProgressTarget(crafter, recipe);
            Quality = CalculateQualityTarget(crafter, recipe);
        }

        public int CraftingPoints { get; }
        public int Durability { get; }
        public int Progress { get; }
        public int Quality { get; }

        private static int CalculateProgressTarget(
            Crafter crafter, 
            Recipe recipe
            )
        {
            return recipe.Difficulty;
        }

        private static int CalculateQualityTarget(
            Crafter crafter, 
            Recipe recipe
            )
        {
            return recipe.Quality;
        }
    }
}