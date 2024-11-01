// File: RunBuddyBackend/Models/Point.cs
using System;

namespace RunBuddyBackend.Models
{
    public class Point
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Point(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"{Latitude}, {Longitude}";
        }
    }
}
