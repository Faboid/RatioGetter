using System;
using System.Collections.Generic;
using System.Text;

namespace RatioGetterLibrary {
    public class Number {

        public Number(string name, uint baseValue, uint? timeout = null) {
            Name = name;
            BaseValue = baseValue;
            this.timeout = timeout;
        }

        public string Name { get; private set; }
        public uint BaseValue { get; }
        public ulong Multiplier { get; private set; } = 1;
        public ulong Result { get => BaseValue * Multiplier; }
        public bool isTimeout { get => (timeout != null) && timeout <= Multiplier; }
        private uint? timeout { get; }

        public void Next(ulong addValue = 1) {
            Multiplier += addValue;
        }
        public override string ToString() {
            if(isTimeout) {
                return $"[Timeout] - {Name}({BaseValue}) * {Multiplier} = {Result}";
            } else {
                return $"{Name}({BaseValue}) * {Multiplier} = {Result}";
            }

        }

    }
}
