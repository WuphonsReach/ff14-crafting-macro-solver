using System;
using System.Collections.Generic;
using System.Linq;
using WuphonsReach.FF14Crafting.Solver.Data.Teamcraft.apps_client_src_assets_data;
using WuphonsReach.FF14Crafting.Solver.Util;

namespace WuphonsReach.FF14Crafting.Solver.Data.Teamcraft
{
    public class TeamcraftDataRepository
    {
        // Loading of the Teamcraft JSON files might end up using a bit of CPU
        // time and memory, even with doing Lazy<T> loading.  Therefore, we'll
        // want to only have a single copy of the dataset floating around in
        // memory.
        
        // This is done as a repository pattern, because we may switch how
        // the data is stored/retrieved in the future.  All access to the
        // dataset needs to go through these public methods.

        public TeamcraftCraftAction CraftActionById(int craftActionId) => 
            CraftActions.Value.TryGetValue(craftActionId, out var result) 
                ? result
                : null;
        
        internal readonly Lazy<IDictionary<int, TeamcraftCraftAction>> CraftActions 
            = new (() =>
            {
                var result = EmbeddedResources.ReadJson<
                    TeamcraftJsonFiles,
                    IDictionary<int, TeamcraftCraftAction>
                    >("craft-actions.json");
                
                foreach (var key in result.Keys) result[key].Id = key;
                
                return result;
            });

        public TeamcraftItem ItemById(int itemId) => 
            Items.Value.TryGetValue(itemId, out var result) 
                ? result
                : null;
        
        internal readonly Lazy<IDictionary<int, TeamcraftItem>> Items 
            = new (() =>
            {
                var result = EmbeddedResources.ReadJson<
                    TeamcraftJsonFiles,
                    IDictionary<int, TeamcraftItem>
                    >("items.json");
                
                foreach (var key in result.Keys) result[key].Id = key;

                return result;
            });

        public TeamcraftRecipe RecipeByItemId(int itemId) => Recipes.Value
            .FirstOrDefault(x => x.ResultId == itemId);

        internal readonly Lazy<ICollection<TeamcraftRecipe>> Recipes
            = new(() =>
            {
                return EmbeddedResources.ReadJson<
                    TeamcraftJsonFiles,
                    ICollection<TeamcraftRecipe>
                >("recipes.json"); 
            });
        
        public TeamcraftJobAbbr JobAbbrById(int itemId) => 
            JobAbbrs.Value.TryGetValue(itemId, out var result) 
                ? result
                : null;
        
        internal readonly Lazy<IDictionary<int, TeamcraftJobAbbr>> JobAbbrs 
            = new (() =>
            {
                var result = EmbeddedResources.ReadJson<
                    TeamcraftJsonFiles,
                    IDictionary<int, TeamcraftJobAbbr>
                    >("job-abbr.json");
                
                foreach (var key in result.Keys) result[key].Id = key;

                return result;
            });

        public TeamcraftJobName JobNameById(int itemId) => 
            JobNames.Value.TryGetValue(itemId, out var result) 
                ? result
                : null;
        
        internal readonly Lazy<IDictionary<int, TeamcraftJobName>> JobNames 
            = new (() =>
            {
                var result = EmbeddedResources.ReadJson<
                    TeamcraftJsonFiles,
                    IDictionary<int, TeamcraftJobName>
                    >("job-name.json");
                
                foreach (var key in result.Keys) result[key].Id = key;

                return result;
            });
    }
}