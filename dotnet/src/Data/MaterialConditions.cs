using System;
using System.Collections.Generic;
using Data.Embedded;

namespace Data
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