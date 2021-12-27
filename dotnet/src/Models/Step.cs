using Data;

namespace Models
{
    public class Step
    {
        /// <summary>The ID of the crafting action for this step.  It must
        /// match up with one of the keys from the <see cref="CraftingActions"/>.
        /// </summary>
        public string Action { get; set; }
    }
}