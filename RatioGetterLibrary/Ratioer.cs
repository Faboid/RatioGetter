using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RatioGetterLibrary {
    /// <summary>
    /// Used to equalize the <see cref="Number.Result"/> of a list of numbers through manipulation of their <see cref="Number.Multiplier"/> value.
    /// </summary>
    public class Ratioer {

        private const ulong DEFAULT_LIMIT = 100000000;

        /// <summary>
        /// Creates a new instance of <see cref="Ratioer"/>, 
        /// which can be used to obtain the ratio to equalize the <see cref="Number.Result"/> 
        /// of a list of numbers through manipulation of their <see cref="Number.Multiplier"/> value.
        /// </summary>
        /// <param name="numbers">The list that will be analyzed.</param>
        /// <param name="approx">Can be set to not require precise ratios.</param>
        /// <param name="limit">Limits the maximum attempts to get a ratio. Can be turned off by putting -1.
        /// Warning: turning it off will result in an infinite loop if the numbers never meet.</param>
        public Ratioer(List<Number> numbers, uint approx = 0, ulong limit = DEFAULT_LIMIT) {
            Numbers = new List<Number>(numbers);
            this.approx = approx;

            if(limit > 0) {
                this.limit = limit;
            } else {
                this.limit = DEFAULT_LIMIT;
            }
        }

        /// <summary>The list that will be analyzed.</summary>
        public List<Number> Numbers { get; private set; }
        private uint approx = 0;
        private ulong limit;
        private ulong currAttempts = 0;

        /// <summary>
        /// Searches the <see cref="Number.Multiplier"/>s needed to equalize <see cref="Number.Result"/>s in the list.
        /// </summary>
        /// <returns>A list of strings that represents the numbers' ratios.</returns>
        public List<string> GetRatios() {

            lock(Numbers) {

                currAttempts = 0;

                while(!Numbers.AreClose(approx) && !Numbers.HasTimeout()) {
                    if(CheckLimit()) {
                        //returns an additional message plus the string version of the current numbers.
                        return LimitBreached();
                    }

                    var curr = Numbers.GetSmaller(Numbers.GetMax());

                    //increases the number's multiplier
                    curr.NextAll(Numbers.GetMax());
                }

                return Numbers.GetStrings().ToList();

            }
        }

        /// <summary>
        /// Adds an attempt to <see cref="currAttempts"/> and checks whether it has exceeded <see cref="limit"/>.
        /// </summary>
        private bool CheckLimit() {
            currAttempts++;
            return currAttempts > limit;
        }

        /// <returns>A <see cref="List(string)"/> with a starting additional message plus the string version of the current numbers.</returns>
        private List<string> LimitBreached() {
            var output = new List<string>() {
                        $"The limit of {limit} attempts has been reached. Results:"
                    };
            output.AddRange(Numbers.GetStrings());
            return output;
        }

    }
}
