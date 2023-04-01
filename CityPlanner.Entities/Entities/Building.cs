namespace CityPlanner.Entities.Entities
{
    public class Building : AbstractEntity
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Street { get; set; } = null!;
        public string OrientationNumber { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string District { get; set; } = null!;

        public int HousingCount { get; set; }
    }
}
