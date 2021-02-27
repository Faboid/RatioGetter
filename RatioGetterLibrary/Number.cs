using System;
using System.Collections.Generic;
using System.Text;

namespace RatioGetterLibrary {
    public class Number {

        public Number(string name, int baseValue, int? timeout = null) {
            Name = name;
            BaseValue = baseValue;
            this.timeout = timeout;
        }

        public string Name { get; private set; }
        public int BaseValue { get; }
        public int Multiplier { get; private set; } = 1;
        public int Result { get => BaseValue * Multiplier; }
        public bool isTimeout { get => (timeout != null) && timeout <= Multiplier; }
        private int? timeout { get; }

        public void Next(int addValue = 1) {
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
