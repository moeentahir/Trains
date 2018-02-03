using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Common
{
    public static class Extensions
    {

        /// <summary>
        /// Tries to parse string to generic type you provide, returns null if cannot.
        /// </summary>
        public static T? TryParseAs<T>(this string @this) where T : struct
        {
            if (@this.IsEmpty()) return default(T?);

            if (typeof(T) == typeof(decimal))
            {
                if (decimal.TryParse(@this, out decimal result))
                    return (T)(object)result;
                else return null;
            }

            if (typeof(T) == typeof(int))
            {
                if (int.TryParse(@this, out int result))
                    return (T)(object)result;
                else return null;
            }

            //TODO: Add more types if needed

            throw new NotImplementedException($"This extension method is not yet implemented for types {typeof(T)}.");
        }

        /// <summary>
        /// Checks whether a string is empty or not
        /// </summary>
        /// <returns>True if object is null or empty</returns>
        public static bool IsEmpty(this string @this) => string.IsNullOrEmpty(@this);

    }
}
