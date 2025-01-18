using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Domain.ValueObjects
{
    public class Name
    {
        public string Firstname { get; }
        public string Lastname { get; }

        public Name(string firstname, string lastname)
        {
            if (string.IsNullOrWhiteSpace(firstname))
                throw new ArgumentException("Firstname cannot be null or empty.", nameof(firstname));
            if (string.IsNullOrWhiteSpace(lastname))
                throw new ArgumentException("Lastname cannot be null or empty.", nameof(lastname));

            Firstname = firstname;
            Lastname = lastname;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Name other)
            {
                return Firstname == other.Firstname && Lastname == other.Lastname;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Firstname, Lastname);
        }

        public override string ToString()
        {
            return $"{Firstname} {Lastname}";
        }
    }
}
