using WuphonsReach.FF14Crafting.Solver.Data;
using WuphonsReach.FF14Crafting.Solver.Models.Results;

namespace WuphonsReach.FF14Crafting.Solver.Models
{
    public class Step
    {
        public CraftingAction Action { get; set; }
        public StepResult Result { get; set; }
    }
}