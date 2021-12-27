using System;

namespace Models
{
    public class Result
    {
        public CraftingPointsResult CraftingPoints { get; set; } = new CraftingPointsResult();
        public DurabilityResult Durability { get; set; } = new DurabilityResult();
        public ProgressResult Progress { get; set; } = new ProgressResult();
        public QualityResult Quality { get; set; } = new QualityResult();
        public StepsResult Steps { get; set; }

        public double Fitness { get; private set; }
        
        public void CalculateFitness()
        {
            //TODO: Calculate fitness
            Fitness = Double.NaN;
        }
    }
}