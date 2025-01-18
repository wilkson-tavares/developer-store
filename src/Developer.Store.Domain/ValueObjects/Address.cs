using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Domain.ValueObjects
{
    public class Address
    {
        public string City { get; }
        public string Street { get; }
        public int Number { get; }
        public string Zipcode { get; }
        public Geolocation Geolocation { get; }

        public Address(string city, string street, int number, string zipcode, Geolocation geolocation)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City cannot be null or empty.", nameof(city));
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street cannot be null or empty.", nameof(street));
            if (number <= 0)
                throw new ArgumentException("Number must be greater than zero.", nameof(number));
            if (string.IsNullOrWhiteSpace(zipcode))
                throw new ArgumentException("Zipcode cannot be null or empty.", nameof(zipcode));

            City = city;
            Street = street;
            Number = number;
            Zipcode = zipcode;
            Geolocation = geolocation ?? throw new ArgumentNullException(nameof(geolocation));
        }

        public override bool Equals(object? obj)
        {
            if (obj is Address other)
            {
                return City == other.City && Street == other.Street && Number == other.Number &&
                       Zipcode == other.Zipcode && Geolocation.Equals(other.Geolocation);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(City, Street, Number, Zipcode, Geolocation);
        }

        public override string ToString()
        {
            return $"{Street}, {Number}, {City}, {Zipcode}, {Geolocation}";
        }
    }
}
