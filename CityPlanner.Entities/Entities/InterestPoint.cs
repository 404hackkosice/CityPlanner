namespace CityPlanner.Entities.Entities
{
    public class InterestPoint : AbstractEntity
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public double X { get; set; }
        public double Y { get; set; }
        public virtual List<Building> NearBuildings { get; set; } = new();
    }
}
