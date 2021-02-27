using RatioGetterLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatioGetterTests {
    public class TestNumber {

        public int Value { get; set; }
        public string Name { get; set; }
        public int Factor { get; set; }
        public int Result { get; set; }
        public int? Timeout { get; set; }

        public TestNumber(int value, string name, int factor, int result, int? timeout = null) {
            Value = value;
            Name = name;
            Factor = factor;
            Result = result;
            Timeout = timeout;
        }

        public override string ToString() => $"{Name}({Value}) * {Factor} = {Result}";

        public Number ToBaseNumber() => new Number(Name, Value, Timeout);

    }

}
