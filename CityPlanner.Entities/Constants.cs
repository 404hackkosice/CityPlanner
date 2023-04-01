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

        public static class PointTypes
        {
            public const string POST_OFFICE = "Pošty";
            public const string DENTAL_CLINIC = "ambulancia zubného lekárstva";
            public const string GENERAL_CLINIC_ADULTS = "Všeobecná ambulancia pre dospelých";
            public const string SUPERMARKET = "supermarket";
            public const string CHEMIST = "chemist";
            public const string PHARMACY = "pharmacy";
            public const string CONVENIENCE = "convenience";
            public const string PARCEL_LOCKER = "parcel_locker";
            public const string PUBLIC_TRANSPORT = "MHD";
            public const string OUTSIDE_GYM = "fitness_station";
            public const string GYM = "fitness_fitness";
            public const string RESTAURANT = "restaurant";
            public const string BAR = "bar";
            public const string PUB = "pub";
            public const string CAFE = "cafe";
            public const string FAST_FOOD = "fast_food";
            public const string DOG_ENCLOSURE = "Vybehy_psy";
        }

        public static class CascadingParameters
        {
            public const string MainLayout = "MainLayout";
        }

        public static readonly string WWW_ROOT = $"{AppDomain.CurrentDomain.BaseDirectory}/wwwroot";
        public static readonly string DATA_PATH = $"{WWW_ROOT}/data";
    }
}
