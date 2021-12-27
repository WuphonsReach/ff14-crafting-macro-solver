using System.Collections.Generic;

namespace Data
{
    public class CraftingAction
    {
        /// <summary>The in-game name for the action.  This may be dependent on language/locale.</summary>
        public string Name { get; set; }
        
        /// <summary>The basic in-game description text for the action. This may be dependent on language/locale.</summary>
        public string Description { get; set; }
        
        /// <summary>Minimum crafting level for the player to obtain this action.</summary>
        public int Level { get; set; }
        
        /// <summary>Action type.  Currently all are "Ability". See <see cref="ActionTypes"/>
        /// for a list of values.</summary>
        public string Type { get; set; }
        
        /// <summary>The number of crafting points (CP) required for this action,
        /// in isolation from other actions.</summary>
        // ReSharper disable once InconsistentNaming
        public int CP { get; set; }
        
        /// <summary>This action is only available when the material status/condition
        /// matches one of these values.  See <see cref="MaterialConditions"/>
        /// for a list of the values.</summary>
        public ICollection<string> WhenMaterialCondition { get; set; }
        
        /// <summary>This action is adjusted, when used in combination with
        /// a prior action.</summary>
        public ICollection<WhenComboAction> WhenCombo { get; set; }
    }
}
