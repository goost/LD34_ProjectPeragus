using System;
using System.Linq;

namespace Goost
{
    public static class Extensions
    {
        public static bool IsIn<T>(this T source, params T[] list)
        {
            if (null == source) throw new ArgumentNullException("source");
            return list.Contains(source);
        }

        // Enable quick and more natural string.Format calls
        public static string F(this string s, params object[] args)
        {
            return string.Format(s, args);
        }

        public static bool CoinToss(this Random rng)
        {
            return rng.Next(2) == 0;
        }

        public static T OneOf<T>(this Random rng, params T[] things)
        {
            return things[rng.Next(things.Length)];
        }

        public static bool Between<T>(this T actual, T lower, T upper) where T : IComparable<T>
        {
            return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) < 0;
        }
    }
}
