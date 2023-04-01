namespace CityPlanner.Entities.DTOs
{
    public class InterestPointsDTO
    {
        public int ExternalId { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public double X { get; set; }
        public double Y { get; set; }
    }
}
