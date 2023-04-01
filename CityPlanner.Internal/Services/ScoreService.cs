namespace CityPlanner.Internal.Services
{
    public class ScoreService
    {
        private double _maxPoints = 0;
        private double _points = 0;
        private Building _building;
        private UserDTO _userData;

        public ScoreService(Building building, UserDTO userData)
        {
            _building = building;
            _userData = userData;
        }

        public ResultsDTO GetResults()
        {
            var results = new ResultsDTO
            {
                PostOfficeResults = ReturnResultFor(true, 3, "Pošty"),
                DentalClinicResults = ReturnResultFor(true, 3, "ambulancia zubného lekárstva"),
                GeneralClinicForAdultsResults = ReturnResultFor(true, 3, "Všeobecná ambulancia pre dospelých"),
                SupermarketResults = ReturnResultFor(true, 3, "supermarket"),
                ChemistResults = ReturnResultFor(true, 3, "chemist"),
                PharmacyResults = ReturnResultFor(true, 3, "pharmacy"),
                ConvenienceResults = ReturnResultFor(true, 3, "convenience"),
                ParcelLockerResults = ReturnResultFor(true, 3, "parcel_locker"),
                PublicTransportResults = ReturnResultFor(true, 3, "MHD"),
                OutsideGymResults = ReturnResultFor(_userData.WantsOutsideGym, 2, "fitness_station"),
                GymResults = ReturnResultFor(_userData.WantsGym, 2, "fitness_fitness"),
                RestaurantResults = ReturnResultFor(_userData.WantsRestaurant, 2, "restaurant"),
                BarResults = ReturnResultFor(_userData.WantsBar, 2, "bar"),
                PubResults = ReturnResultFor(_userData.WantsPub, 2, "pub"),
                CafeResults = ReturnResultFor(_userData.WantsCafe, 2, "cafe"),
                FastFoodResults = ReturnResultFor(_userData.WantsFastFood, 2, "fast_food"),
                DogEnclosuresResults = ReturnResultFor(_userData.WantsDogEnclosure, 2, "Vybehy_psy"),

                Score = Math.Round(_points / _maxPoints * 100, 1)
            };

            return results;
        }

        private PerTypeResultsDTO ReturnResultFor(bool shouldBeIncluded, int weight, string type)
        {
            if(!shouldBeIncluded)
            {
                return new()
                {
                    ClosestDistance = null,
                    ClosestPoint = null,
                    PointsByClosest = new(),
                    TotalCount = 0
                };
            }

            _maxPoints += weight;

            var matchingPoints = _building.NearInterestPoints.Where(x => x.Type.Equals(type));

            if(!matchingPoints.Any())
            {
                return new()
                {
                    ClosestDistance = null,
                    ClosestPoint = null,
                    PointsByClosest = new(),
                    TotalCount = 0
                };
            }

            Dictionary<InterestPoint, double> distances = new();

            foreach(var matchingPoint in matchingPoints)
            {
                distances.Add(matchingPoint, DistanceHelper.CalculateDistance(matchingPoint.X, matchingPoint.Y, _building.X, _building.Y));
            }

            distances = distances.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            _points += weight;

            return new()
            {
                PointsByClosest = distances.Select(x => x.Key).ToList(),
                ClosestDistance = distances.First().Value,
                ClosestPoint = distances.First().Key,
                TotalCount = distances.Count
            };
        }
    }
}
