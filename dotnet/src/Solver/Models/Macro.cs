using System.Collections.Generic;
using WuphonsReach.FF14Crafting.Solver.Models.Results;

namespace WuphonsReach.FF14Crafting.Solver.Models
{
    public class Macro
    {
        public string Name { get; set; }
        
        public List<Step> Steps { get; set; }
        
        public StepResult FinalStepResult { get; private set; }
    }
}