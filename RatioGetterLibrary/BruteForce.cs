using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RatioGetterLibrary {
    public static class BruteForce {

        public static List<string> GetRatios(this List<Number> numbers) {

            while(!numbers.AreEqual() && !numbers.HasTimeout()) {
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

        private static IEnumerable<Number> GetSmaller(this List<Number> numbers, int currentMax) => numbers.Where(x => x.Result != currentMax);

        private static int GetMax(this List<Number> numbers) => numbers.Max(x => x.Result);

        private static int CalculateIncreaseValue(Number number, int currentMax) {
            int value = (currentMax / number.BaseValue) - number.Multiplier;

            //if the value is 0(it happens when the current result is near the max value), returns 1 to surpass the max
            return (value > 0) ? value : 1;
        }

    }
}
