namespace WuphonsReach.FF14Crafting.Solver.Data.Teamcraft
{
    public static class IHasTeamcraftLanguagesExtensions
    {
        public static string Name(
            this IHasTeamcraftLanguages x
            )
        {
            // later, this method will take a locale argument, for now return English

            // Not all things have a name defined (unused IDs), map to null
            return string.IsNullOrWhiteSpace(x.English)
                ? null
                : x.English;
        }
    }
}