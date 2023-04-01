namespace CityPlanner.Entities.Entities
{
    public class BusStop : AbstractEntity
    {
        public int Pasport { get; set; }
        public int Sl { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public string Name { get; set; } = null!;
        public string Direction { get; set; } = null!;

        public string District { get; set; } = null!;

        public bool Tram { get; set; }
        public bool Trolley { get; set; }
        public bool Bus { get; set; }
    }
}
