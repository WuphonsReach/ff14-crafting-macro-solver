using System.Collections.Generic;
using WuphonsReach.FF14Crafting.Solver.Models;
using Xunit;

namespace WuphonsReach.FF14Crafting.Solver.Tests.Models
{
    public class TargetTests
    {
        // The current math is "difficulty -> 100% progress" and "quality -> 100% quality chance".
        // Gave up trying to calculate expected quality, just using data from recipe object.
        
        public static IEnumerable<object[]> CalculateProgressQualityMemberData => new List<object[]>
        {
            // level/craftsmanship/control, level/difficulty/quality, expected progress/quality
            new object[] { 50, 214, 264,    1, 9, 80,       9, 80 }, // table salt
            new object[] { 50, 214, 264,    4, 10, 104,     10, 104 }, // honey
            new object[] { 50, 214, 264,    3, 20, 120,     20, 120 }, // boiled egg
            new object[] { 50, 214, 264,    6, 18, 136,     18, 136 }, // sweet cream
            new object[] { 50, 214, 264,    7, 18, 152,     18, 152 }, // smooth butter
            new object[] { 50, 214, 264,    14, 27, 264,    27, 264 }, // pie dough
            new object[] { 50, 214, 264,    18, 67, 450,    67, 450 }, // walnut bread
            new object[] { 50, 214, 264,    22, 75, 570,    75, 570 }, // dried plums
            new object[] { 50, 214, 264,    24, 85, 630,    85, 630 }, // chamomile tea
            new object[] { 50, 214, 264,    28, 100, 760,   100, 760 }, // crumpet
            new object[] { 50, 214, 264,    48, 172, 1880,  172, 1880 }, // crowned pie
        };

        [Theory]
        [MemberData(nameof(CalculateProgressQualityMemberData))]
        public void CalculateProgressQuality_returns_correct_results(
            int crafterLevel,
            int crafterCraftsmanship,
            int crafterControl,
            int recipeLevel,
            int recipeDifficulty,
            int recipeQuality,
            int expectedProgressTarget,
            int expectedQualityTarget
            )
        {
            var crafter = new Crafter
            {
                Level = crafterLevel,
                Craftsmanship = crafterCraftsmanship,
                Control = crafterControl,
            };
            var recipe = new Recipe
            {
                Level = recipeLevel,
                Difficulty = recipeDifficulty,
                Quality = recipeQuality,
            };
            var target = new Target(crafter, recipe);

            Assert.True(
                target.Progress == expectedProgressTarget, 
                $"Progress: expected {expectedProgressTarget}, got {target.Progress}"
                );
            Assert.True(
                target.Quality == expectedQualityTarget, 
                $"Quality: expected {expectedQualityTarget}, got {target.Quality}."
                );
        }
    }
}