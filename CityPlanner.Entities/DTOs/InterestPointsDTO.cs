namespace CityPlanner.Entities.DTOs
{
    public class InterestPointsDTO
    {
        public int ExternalId { get; set; }
        public string Name { get; set; } = null!;
        public string TypeOne { get; set; } = null!;
        public string TypeTwo { get; set; } = null!;
        public double X { get; set; }
        public double Y { get; set; }
        public string Geometry { get; set; } = null!;
        public string Poly15 { get; set; } = null!;
    }
}
