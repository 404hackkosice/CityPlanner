namespace CityPlanner.Entities.Entities
{
    public class BuildingDTO : AbstractEntity
    {
        public int ExternalId { get; set; }
        public string Geometry { get; set; } = null!;
        public double X { get; set; }
        public double Y { get; set; }
        public string Street { get; set; } = null!;
        public string OrientationNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string District { get; set; } = null!;
        public string DistrictTwo { get; set; } = null!;
        public string LegalArea { get; set; } = null!;
        public double HousingCount { get; set; }
    }
}
