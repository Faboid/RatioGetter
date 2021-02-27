using System;
using Xunit;
using RatioGetterLibrary;
using System.Collections.Generic;
using System.Collections;
using static RatioGetterTests.ListTestNumbers;

namespace RatioGetterTests {
    public class BruteForceTests {

        public static IEnumerable<object[]> TwoNumbers { get => TwoNumbers(); }
        public static IEnumerable<object[]> ThreeNumbers { get => ThreeNumbers(); }
        public static IEnumerable<object[]> FiveNumbers { get => FiveNumbers(); }

        [Theory]
        [MemberData(nameof(TwoNumbers))]
        [MemberData(nameof(ThreeNumbers))]
        [MemberData(nameof(FiveNumbers))]
        public void GetRatios_NoTimeoutValues_Correctly(List<TestNumber> testNumbers) {

            List<Number> numbers = testNumbers.ConvertAll(x => x.ToBaseNumber());

            List<string> expected = testNumbers.ConvertAll(x => x.ToString());

            Assert.Equal(expected, numbers.GetRatios());
        }

    }
}
