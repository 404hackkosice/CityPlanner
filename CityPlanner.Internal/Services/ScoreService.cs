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
                PostOfficeResults = ReturnResultFor(true, 3, Constants.PointTypes.POST_OFFICE),
                DentalClinicResults = ReturnResultFor(true, 3, Constants.PointTypes.DENTAL_CLINIC),
                GeneralClinicForAdultsResults = ReturnResultFor(true, 3, Constants.PointTypes.GENERAL_CLINIC_ADULTS),
                SupermarketResults = ReturnResultFor(true, 3, Constants.PointTypes.SUPERMARKET),
                ChemistResults = ReturnResultFor(true, 3, Constants.PointTypes.CHEMIST),
                PharmacyResults = ReturnResultFor(true, 3, Constants.PointTypes.PHARMACY),
                ConvenienceResults = ReturnResultFor(true, 3, Constants.PointTypes.CONVENIENCE),
                ParcelLockerResults = ReturnResultFor(true, 3, Constants.PointTypes.PARCEL_LOCKER),
                PublicTransportResults = ReturnResultFor(true, 3, Constants.PointTypes.PUBLIC_TRANSPORT),
                OutsideGymResults = ReturnResultFor(_userData.WantsOutsideGym, 2, Constants.PointTypes.OUTSIDE_GYM),
                GymResults = ReturnResultFor(_userData.WantsGym, 2, Constants.PointTypes.GYM),
                RestaurantResults = ReturnResultFor(_userData.WantsRestaurant, 2, Constants.PointTypes.RESTAURANT),
                BarResults = ReturnResultFor(_userData.WantsBar, 2, Constants.PointTypes.BAR),
                PubResults = ReturnResultFor(_userData.WantsPub, 2, Constants.PointTypes.PUB),
                CafeResults = ReturnResultFor(_userData.WantsCafe, 2, Constants.PointTypes.CAFE),
                FastFoodResults = ReturnResultFor(_userData.WantsFastFood, 2, Constants.PointTypes.FAST_FOOD),
                DogEnclosuresResults = ReturnResultFor(_userData.WantsDogEnclosure, 2, Constants.PointTypes.DOG_ENCLOSURE),
                PublicElementarySchoolResults = ReturnResultFor(_userData.WantsPublicElementarySchool, (int) _userData.Children, Constants.PointTypes.PUBLIC_ELEMENTARY_SCHOOL),
                PrivateElementarySchoolResults = ReturnResultFor(_userData.WantsPrivateElementarySchool, (int)_userData.Children, Constants.PointTypes.PRIVATE_ELEMENTARY_SCHOOL),
                ReligiousElementarySchoolResults = ReturnResultFor(_userData.WantsReligiousElementarySchool, (int)_userData.Children, Constants.PointTypes.RELIGIOUS_ELEMENTARY_SCHOOL),
                PublicKindergartenResults = ReturnResultFor(_userData.WantsPublicKindergarten, (int)_userData.Children, Constants.PointTypes.PUBLIC_KINDERGARTEN),
                PrivateKindergartenResults = ReturnResultFor(_userData.WantsPrivateKindergarten, (int)_userData.Children, Constants.PointTypes.PRIVATE_KINDERGARTEN),
                ReligiousKindergartenResults = ReturnResultFor(_userData.WantsReligiousKindergarten, (int)_userData.Children, Constants.PointTypes.RELIGIOUS_KINDERGARTEN),
                PlaygroundResults = ReturnResultFor(_userData.Children != Entities.Enums.ChildAspirations.NotPlanned, (int)_userData.Children, Constants.PointTypes.PLAYGROUND),
                GeneralClinicForChildrenResults = ReturnResultFor(_userData.Children != Entities.Enums.ChildAspirations.NotPlanned, (int)_userData.Children, Constants.PointTypes.GENERAL_CLINIC_CHILDREN),
                Score = Math.Round(_points / _maxPoints * 100)
            };

            if (results.DogEnclosuresResults.TotalCount > 0)
                results.PetLovers = true;

            if (results.BarResults.TotalCount > 0)
                results.NightLife = true;

            if (results.PlaygroundResults.TotalCount > 0 && results.GeneralClinicForChildrenResults.TotalCount > 0)
                results.ForKids = true;

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
