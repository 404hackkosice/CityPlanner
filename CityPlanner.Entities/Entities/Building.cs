namespace CityPlanner.Entities.Entities
{
    public class Building : AbstractEntity
    {
        public double X { get; set; }
        public double Y { get; set; }

        public string Street { get; set; } = null!;
        public string OrientationNumber { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string District { get; set; } = null!;

        public int HousingCount { get; set; }
    }
}
