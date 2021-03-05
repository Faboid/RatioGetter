using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RatioGetterLibrary {
    public static class BruteForce {

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

        private static bool AreEqual(this List<Number> numbers) => numbers.All(x => x.Result == numbers[0].Result);

        private static bool HasTimeout(this List<Number> numbers) => numbers.Any(x => x.isTimeout);

        private static List<string> GetStrings(this List<Number> numbers) => numbers.ConvertAll(x => x.ToString());

        private static IEnumerable<Number> GetSmaller(this List<Number> numbers, ulong currentMax) => numbers.Where(x => x.Result != currentMax);

        private static ulong GetMax(this List<Number> numbers) => numbers.Max(x => x.Result);

        private static ulong CalculateIncreaseValue(Number number, ulong currentMax) {
            ulong value = (currentMax / number.BaseValue) - number.Multiplier;

            //if the value is 0(it happens when the current result is near the max value), returns 1 to surpass the max
            return (value > 0) ? value : 1;
        }

    }
}
