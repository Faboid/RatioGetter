using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatioGetterLibrary {
    public static class NumberList {

        /// <returns>If all the <see cref="Number.Result"/> are equal.</returns>
        public static bool AreEqual(this List<Number> numbers) => numbers.All(x => x.Result == numbers[0].Result);

        public static bool AreClose(this List<Number> numbers, uint approxValue) {
            return numbers.All(x => 
                x.Result >= numbers[0].Result - approxValue
                && 
                x.Result <= numbers[0].Result + approxValue
                );
        }

        /// <returns>If any <see cref="Number"/> has <see cref="Number.IsTimeout"/> set as true.</returns>
        public static bool HasTimeout(this List<Number> numbers) => numbers.Any(x => x.IsTimeout);

        /// <summary>
        /// Converts a list of <see cref="Number"/> into a list of <see cref="string"/>
        /// </summary>
        public static List<string> GetStrings(this List<Number> numbers) => numbers.ConvertAll(x => x.ToString());

    }
}
