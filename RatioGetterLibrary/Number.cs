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
        public bool IsTimeout { get => (timeout != null) && timeout <= Multiplier; }
        private uint? timeout { get; }

        public void Next(ulong addValue = 1) {
            Multiplier += addValue;
        }
        public override string ToString() {
            if(IsTimeout) {
                return $"[Timeout] - {Name}({BaseValue}) * {Multiplier} = {Result}";
            } else {
                return $"{Name}({BaseValue}) * {Multiplier} = {Result}";
            }

        }

        public static bool TryParse(string s, out Number result) {
            result = null;
            var fields = s.Split(' ');

            if(fields.Length == 2) {
                if(uint.TryParse(fields[1], out uint baseValue)) {
                    result = new Number(fields[0], baseValue);
                    return true;
                }
            } else if (fields.Length == 3){
                if(uint.TryParse(fields[1], out uint baseValue) && (uint.TryParse(fields[2], out uint timeout))) {
                    result = new Number(fields[0], baseValue, timeout);
                    return true;
                }
            }

            return false;
        }

    }
}
