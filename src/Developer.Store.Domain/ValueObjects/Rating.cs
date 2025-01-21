using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Domain.ValueObjects
{
    public class Rating
    {
        public decimal Rate { get; }
        public int Count { get; }

        public Rating(decimal rate, int count)
        {
            if (rate < 0 || rate > 5)
                throw new ArgumentException("Rate must be between 0 and 5.", nameof(rate));
            if (count < 0)
                throw new ArgumentException("Count must be a non-negative integer.", nameof(count));

            Rate = rate;
            Count = count;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Rating other)
            {
                return Rate == other.Rate && Count == other.Count;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Rate, Count);
        }

        public override string ToString()
        {
            return $"Rate: {Rate}, Count: {Count}";
        }
    }
}
