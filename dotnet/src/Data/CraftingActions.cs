using System;
using System.Collections.Generic;
using Data.Embedded;

namespace Data
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