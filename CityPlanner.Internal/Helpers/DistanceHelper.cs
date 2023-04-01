namespace CityPlanner.Internal.Helpers
{
    public static class DistanceHelper
    {
        public static double CalculateDistance(double lat1, double long1, double lat2, double long2)
        {
            const double R = 6371000; // Earth's radius in meters
            var φ1 = ToRadians(lat1);
            var φ2 = ToRadians(lat2);
            var Δφ = ToRadians(lat2 - lat1);
            var Δλ = ToRadians(long2 - long1);

            var Δφhalfsin = Math.Sin(Δφ / 2);
            var Δλhalfsin = Math.Sin(Δλ / 2);

            var a = Δφhalfsin * Δφhalfsin +
                    Math.Cos(φ1) * Math.Cos(φ2) *
                    Δλhalfsin * Δλhalfsin;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distanceInMeters = R * c;
            return distanceInMeters;
        }

        private static double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}
