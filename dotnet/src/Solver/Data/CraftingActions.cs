using System;
using System.Collections.Generic;
using WuphonsReach.FF14Crafting.Solver.Util;

namespace WuphonsReach.FF14Crafting.Solver.Data
{
    /// <summary>Loaded from CraftingActions.json embedded file.</summary>
    public class CraftingActions
    {
        public Lazy<IDictionary<string, CraftingAction>> All = new(Initialize);

        private static IDictionary<string, CraftingAction> Initialize()
        {
            return EmbeddedResources.ReadJson<
                CraftingActions,
                IDictionary<string, CraftingAction>
                >("CraftingActions.json");
        }
    }
}