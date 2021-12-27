using System.Collections.Generic;

namespace Models
{
    public class Macro
    {
        public string Name { get; set; }
        
        public List<Step> Steps { get; set; } = new List<Step>();

        public Result Result { get; private set; }

        public void CalculateResult(
            Crafter crafter,
            Recipe recipe
            )
        {
            // TODO: Calculate Result object
            Result = null;
        }
    }
}