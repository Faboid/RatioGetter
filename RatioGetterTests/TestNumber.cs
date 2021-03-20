using RatioGetterLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatioGetterTests {
    public class TestNumber {

        public uint BaseValue { get; set; }
        public string Name { get; set; }
        public ulong Multiplier { get; set; }
        public ulong Result { get; set; }
        public uint? Timeout { get; set; }
        public bool IsTimeout { get => (Timeout != null) && Timeout <= Multiplier; }

        public TestNumber(uint value, string name, ulong multiplier, ulong result, uint? timeout = null) {
            BaseValue = value;
            Name = name;
            Multiplier = multiplier;
            Result = result;
            Timeout = timeout;
        }

        public string ToString(bool ignoreTimeout = false) {
            if(IsTimeout && !ignoreTimeout) {
                return $"[Timeout] - {Name}({BaseValue}) * {Multiplier} = {Result}";
            } else {
                return $"{Name}({BaseValue}) * {Multiplier} = {Result}";
            } 
        }

        public Number ToBaseNumber() => new Number(Name, BaseValue, Timeout);

    }

}
