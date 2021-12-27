using System;

namespace WuphonsReach.FF14Crafting.Solver.Models.Results
{
    /// <summary>The result after performing the <see cref="Step"/> on the product.</summary>
    public class StepResult
    {
        public double? Fitness { get; private set; }

        public CraftingPointsStepResult CraftingPoints { get; set; }
        public DurabilityStepResult Durability { get; set; }
        public ProgressStepResult Progress { get; set; }
        public QualityStepResult Quality { get; set; }
    }
}