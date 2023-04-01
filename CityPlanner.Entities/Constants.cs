namespace CityPlanner.Entities
{
    public static class Constants
    {
        public static class Limits
        {
            public const int MINIMUM_SECOND_HOSTED_SERVICE_DELAY = 1;
        }

        public static class CsvFiles
        {
            public const string POINTS_OF_INTEREST = "POIs.csv";
            public const string ADDRESSES = "addresses.csv";
        }


        public static readonly string WWW_ROOT = $"{AppDomain.CurrentDomain.BaseDirectory}/wwwroot";
        public static readonly string DATA_PATH = $"{WWW_ROOT}/data";
    }
}
