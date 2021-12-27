namespace Data
{
    public class WhenComboAction
    {
        /// <summary>The action that must be the previous "combo step".  Not
        /// all actions reset combos.</summary>
        public string Action { get; set; }
        
        /// <summary>The crafting points (CP) value to use when this action
        /// is used in conjunction with the combo action.</summary>
        // ReSharper disable once InconsistentNaming
        public int? CP { get; set; }
    }
}