using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RatioGetterLibrary {
    /// <summary>
    /// Used to equalize the <see cref="Number.Result"/> of a list of numbers through manipulation of their <see cref="Number.Multiplier"/> value.
    /// </summary>
    public class Ratioer {

        private const long DEFAULT_LIMIT = 100000000;

        /// <summary>
        /// Creates a new instance of <see cref="Ratioer"/>, 
        /// which can be used to obtain the ratio to equalize the <see cref="Number.Result"/> 
        /// of a list of numbers through manipulation of their <see cref="Number.Multiplier"/> value.
        /// </summary>
        /// 
        /// <param name="numbers">The list that will be analyzed.</param>
        /// 
        /// <param name="approx">Can be set to not require precise ratios.</param>
        /// 
        /// <param name="limit">Limits the maximum attempts to get a ratio. 
        /// <para/>Set to 0 to set to the default limit(<see cref="DEFAULT_LIMIT"/>). 
        /// <br/>Set negative to ignore the limits(Warning: ignoring the limits has a huge chance of getting an infinite loop).
        /// </param>
        public Ratioer(List<Number> numbers, uint approx = 0, long limit = 0) {
            Numbers = new List<Number>(numbers);
            this.approx = approx;

            SetLimit(limit);
        }

        /// <summary>
        /// If <paramref name="limit"/> is:
        /// 
        /// <para/>Negative - Sets <see cref="ignoreLimit"/> to false to ignore <see cref="limit"/>.
        /// <br/>0 - Sets <see cref="limit"/> to default value.
        /// <br/>Positive - Sets <see cref="limit"/> to <paramref name="limit"/>
        /// </summary>
        /// <param name="limit"></param>
        private void SetLimit(long limit) {
            if(limit < 0) {
                ignoreLimit = true;
            } else if(limit > 0) {
                this.limit = limit;
            } else {
                this.limit = DEFAULT_LIMIT;
            }
        }

        /// <summary>The list that will be analyzed.</summary>
        public List<Number> Numbers { get; private set; }
        private uint approx = 0;
        private long currAttempts = 0;
        private long limit = 100000000;
        private bool ignoreLimit = false;

        /// <summary>
        /// Searches the <see cref="Number.Multiplier"/>s needed to equalize <see cref="Number.Result"/>s in the list.
        /// </summary>
        /// <returns>A list of strings that represents the numbers' ratios.</returns>
        public List<string> GetRatios() {

            lock(Numbers) {

                currAttempts = 0;

                while(!Numbers.AreClose(approx) && !Numbers.HasTimeout()) {

                    if(!ignoreLimit && CheckLimit()) {
                        //returns an additional message plus the string version of the current numbers.
                        return LimitBreached();
                    }

                    var curr = Numbers.GetSmaller(Numbers.GetMax());

                    //increases the number's multiplier
                    curr.NextAll(Numbers.GetMax());
                }

                return Numbers.GetStrings(Numbers.AreClose(approx)).ToList();

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
