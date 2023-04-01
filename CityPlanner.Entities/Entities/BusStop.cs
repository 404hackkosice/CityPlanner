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

        public Boolean Tram { get; set; }
        public Boolean Trolley { get; set; }
        public Boolean Bus { get; set; }
    }
}
