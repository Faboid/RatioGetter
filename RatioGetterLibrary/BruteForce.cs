using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RatioGetterLibrary {
    //todo - convert this into a non-static class, make it threadsafe, and automate whether to use the approximate or limited ratio.
    public static class BruteForce {

        /// <summary>
        /// Gets the multiplier needed to achieve the same result.
        /// </summary>
        /// <param name="numbers">The list of numbers that will be checked.</param>
        /// <param name="limit">The maximum amount of attempts before stopping.</param>
        /// <returns>A list of strings that shows the correct ratios and results.</returns>
        public static List<string> GetRatios(this List<Number> numbers, ulong limit = 100000000) {
            ulong currAttempts = 0;

            while(!numbers.AreEqual() && !numbers.HasTimeout()) {
                currAttempts++;
                if(currAttempts > limit) {
                    var output = new List<string>() { $"The limit of {limit} attempts has been reached. Results:" };
                    output.AddRange(numbers.GetStrings());
                    return output;
                }

                //gets all numbers but the biggest ones
                var curr = numbers.GetSmaller(numbers.GetMax());

                foreach(Number num in curr) {
                    //increases the number's multiplier
                    num.Next(CalculateIncreaseValue(num, numbers.GetMax()));
                }
            }

            return numbers.GetStrings();
        }

        public static List<string> GetApproxRatios(this List<Number> numbers, uint approx = 0, ulong limit = 100000000) {
            ulong currAttempts = 0;

            while(!numbers.AreClose(approx) && !numbers.HasTimeout()) {
                currAttempts++;
                if(currAttempts > limit) {
                    var output = new List<string>() { $"The limit of {limit} attempts has been reached. Results:" };
                    output.AddRange(numbers.GetStrings());
                    return output;
                }

                //gets all numbers but the biggest ones
                var curr = numbers.GetSmaller(numbers.GetMax());
                
                foreach(Number num in curr) {
                    //increases the number's multiplier
                    num.Next(CalculateIncreaseValue(num, numbers.GetMax()));
                }
            }

            return numbers.GetStrings();
        }

        private static IEnumerable<Number> GetSmaller(this List<Number> numbers, ulong currentMax) => numbers.Where(x => x.Result != currentMax);

        private static ulong GetMax(this List<Number> numbers) => numbers.Max(x => x.Result);

        private static ulong CalculateIncreaseValue(Number number, ulong currentMax) {
            ulong value = (currentMax / number.BaseValue) - number.Multiplier;

            //if the value is 0(it happens when the current result is near the max value), returns 1 to surpass the max
            return (value > 0) ? value : 1;
        }

    }
}
