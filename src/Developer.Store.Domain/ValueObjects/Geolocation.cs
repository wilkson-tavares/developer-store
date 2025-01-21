using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Domain.ValueObjects
{
    public class Geolocation
    {
        public string Lat { get; }
        public string Long { get; }

        public Geolocation(string lat, string @long)
        {
            if (string.IsNullOrWhiteSpace(lat))
                throw new ArgumentException("Latitude cannot be null or empty.", nameof(lat));
            if (string.IsNullOrWhiteSpace(@long))
                throw new ArgumentException("Longitude cannot be null or empty.", nameof(@long));

            Lat = lat;
            Long = @long;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Geolocation other)
            {
                return Lat == other.Lat && Long == other.Long;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Lat, Long);
        }

        public override string ToString()
        {
            return $"{Lat}, {Long}";
        }
    }
}
