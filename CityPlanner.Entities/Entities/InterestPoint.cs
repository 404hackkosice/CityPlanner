﻿namespace CityPlanner.Entities.Entities
{
    public class InterestPoint : AbstractEntity
    {
        public string Name { get; set; } = null!;
        public string TypeOne { get; set; } = null!;
        public string TypeTwo { get; set; } = null!;
        public double X { get; set; }
        public double Y { get; set; }
        public string Poly15 { get; set; } = null!;
    }
}