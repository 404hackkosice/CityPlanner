namespace CityPlanner.Internal.Helpers
{
    public static class SearchExtensions
    {
        public static string NormalizeForSearch(this string input)
            => input.ToLower().Replace("á", "a").Replace("ä", "a").Replace("č", "c").Replace("ď", "d").Replace("é", "e")
            .Replace("ě", "e").Replace("í", "i").Replace("ľ", "l").Replace("ĺ", "l").Replace("ň", "n").Replace("ó", "o")
            .Replace("ô", "o").Replace("ř", "r").Replace("ŕ", "r").Replace("š", "s").Replace("ť", "t").Replace("ú", "u")
            .Replace("ý", "y").Replace("ž", "z").Replace(" ", "").Replace(".", "").Replace(",", "").Replace("-", "");
    }
}
