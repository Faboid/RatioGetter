using System;
using System.Collections.Generic;
using System.Text;

namespace RatioGetterTests {
    public static class ListTestNumbers {

        public static IEnumerable<object[]> TwoNumbers() {
            yield return new object[] {
                new List<TestNumber> {
                    new TestNumber(2, "two", 5, 10),
                    new TestNumber(5, "five", 2, 10)
                }
            };
        }

        public static IEnumerable<object[]> ThreeNumbers() {
            yield return new object[] {
                new List<TestNumber> {
                    new TestNumber(45, "first", 8, 360),
                    new TestNumber(60, "second", 6, 360),
                    new TestNumber(120, "third", 3, 360)
                }
            };
        }

        public static IEnumerable<object[]> FiveNumbers() {
            yield return new object[] {
                new List<TestNumber> {
                    new TestNumber(57, "first", 6106100, 348047700),
                    new TestNumber(77, "second", 4520100, 348047700),
                    new TestNumber(100, "third", 3480477, 348047700),
                    new TestNumber(183, "fourth", 1901900, 348047700),
                    new TestNumber(13, "fifth", 26772900, 348047700)
                }
            };
        }

        public static IEnumerable<object[]> ThreeTimeoutNumbers() {
            yield return new object[] {
                new List<TestNumber> {
                    //todo - add numbers
                }
            };
        }


    }
}
