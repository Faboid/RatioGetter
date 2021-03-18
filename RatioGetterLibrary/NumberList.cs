using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatioGetterLibrary {
    /// <summary>
    /// Several static methods to use on <see cref="IEnumerable(Number)"/> and similar.
    /// </summary>
    public static class NumberList {

        /// <returns>If all the <see cref="Number.Result"/> are equal.</returns>
        public static bool AreEqual(this IEnumerable<Number> numbers) => numbers.All(x => x.Result == numbers.First().Result);

        /// <returns>If all the <see cref="Number.Result"/> are within <paramref name="approxValue"/>'s range to the first number.</returns>
        public static bool AreClose(this IEnumerable<Number> numbers, uint approxValue) {
            if(approxValue == 0) {
                //this makes less comparisons and is thus faster
                return numbers.AreEqual();
            }

            return numbers.All(x => x.Result.IsClose(numbers.First().Result, approxValue));
        }

        public static bool IsClose(this ulong number, ulong toNum, uint approxValue) {
            return (number >= toNum - approxValue) && (number <= toNum + approxValue);
        }

        /// <returns>If any <see cref="Number"/> has <see cref="Number.IsTimeout"/> set as true.</returns>
        public static bool HasTimeout(this IEnumerable<Number> numbers) => numbers.Any(x => x.IsTimeout);

        /// <summary>
        /// Converts a list of <see cref="Number"/> into a list of <see cref="string"/>
        /// </summary>
        public static IEnumerable<string> GetStrings(this IEnumerable<Number> numbers, bool ignoreTimeout = false) => numbers.Select(x => x.ToString(ignoreTimeout));

        public static IEnumerable<Number> GetSmaller(this IEnumerable<Number> numbers, ulong currentMax) => numbers.Where(x => x.Result != currentMax);
        public static ulong GetMax(this IEnumerable<Number> numbers) => numbers.Max(x => x.Result);

        public static void NextAll(this IEnumerable<Number> numbers, ulong currentMax) {
            //increases the numbers' multiplier
            numbers.ForEach(x => x.Next(CalculateIncreaseValue(x, currentMax)));
        }

        public static ulong CalculateIncreaseValue(Number number, ulong currentMax) {
            ulong value = (currentMax / number.BaseValue) - number.Multiplier;

            //if the value is 0(it happens when the current result is near the max value), returns 1 to surpass the max
            return (value > 0) ? value : 1;
        }

    }
}
