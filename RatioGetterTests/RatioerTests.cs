using System;
using Xunit;
using RatioGetterLibrary;
using System.Collections.Generic;
using System.Collections;
using static RatioGetterTests.ListTestNumbers;

namespace RatioGetterTests {
    public class RatioerTests {

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

            Ratioer ratioer = new Ratioer(numbers);

            Assert.Equal(expected, ratioer.GetRatios());
        }

        [Fact]
        public void GetRatios_OverrideTimeout() {
            List<TestNumber> testNumbers = new List<TestNumber>() {
                new TestNumber(35, "first", 6, 210),
                new TestNumber(99, "second", 2, 198)
            };
            int limit = 5;

            Ratioer ratioer = new Ratioer(testNumbers.ConvertAll(x => x.ToBaseNumber()), 0, limit);

            List<string> expected = new List<string>() {
                $"The limit of {limit} attempts has been reached. Results:"
            };
            expected.AddRange(testNumbers.ConvertAll(x => x.ToString(false)));

            Assert.Equal(expected, ratioer.GetRatios());
        }

        [Fact]
        public void GetRatios_ApproximateValue() {
            List<TestNumber> testNumbers = new List<TestNumber>() {
                new TestNumber(33, "first", 3, 99),
                new TestNumber(50, "second", 2, 100)
            };
            uint approx = 5;

            Ratioer ratioer = new Ratioer(testNumbers.ConvertAll(x => x.ToBaseNumber()), approx);

            List<string> expected = testNumbers.ConvertAll(x => x.ToString(false));

            Assert.Equal(expected, ratioer.GetRatios());
        }

        [Fact]
        public void GetRatios_NoTimeoutOnLastAttempt() {
            List<TestNumber> testNumbers = new List<TestNumber>() {
                new TestNumber(14, "second", 5, 70, 5),
                new TestNumber(35, "first", 2, 70)
            };

            Ratioer ratioer = new Ratioer(testNumbers.ConvertAll(x => x.ToBaseNumber()));
            List<string> expected = testNumbers.ConvertAll(x => x.ToString(true));

            Assert.Equal(expected, ratioer.GetRatios());
        }
    }
}
