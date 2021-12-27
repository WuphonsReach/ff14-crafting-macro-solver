using System;
using System.Collections.Generic;
using EmbeddedResources = WuphonsReach.FF14Crafting.Solver.Util.EmbeddedResources;

namespace WuphonsReach.FF14Crafting.Solver.Data
{
    /// <summary>Loaded from MaterialConditions.json embedded file.</summary>
    public class MaterialConditions
    {
        public Lazy<IDictionary<string, MaterialCondition>> All = new(Initialize);

        private static IDictionary<string, MaterialCondition> Initialize()
        {
            return EmbeddedResources.ReadJson<
                MaterialConditions,
                IDictionary<string, MaterialCondition>
                >("MaterialConditions.json");
        }
    }
}