using CityPlanner.Entities.Entities;

namespace CityPlanner.Entities.DTOs
{
    public class PerTypeResultsDTO
    {
        public int TotalCount { get; set; }

        public double? ClosestDistance { get; set; }

        public InterestPoint? ClosestPoint { get; set; }

        public List<InterestPoint> PointsByClosest { get; set; } = new();
    }
}
