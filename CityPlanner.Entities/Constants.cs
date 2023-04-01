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
            public const string POINTS_OF_INTEREST = "POIs_location_catchments.csv";
            public const string ADDRESSES = "adresne_body_byty_KE.csv";
        }


        public static readonly string WWW_ROOT = $"{AppDomain.CurrentDomain.BaseDirectory}/wwwroot";
        public static readonly string DATA_PATH = $"{WWW_ROOT}/data";
    }
}
