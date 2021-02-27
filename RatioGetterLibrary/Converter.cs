using System;
using System.Collections.Generic;
using System.Text;

namespace RatioGetterLibrary {
    public static class Converter {

        public static bool TryParseToNumber(string line, out Number number) {
            number = null;
            var fields = line.Split(' ');
            if(fields.Length == 2) {
                return TryCreateNumber(fields, out number);
            } else if(fields.Length == 3) {
                return TryCreateNumberWithTimeout(fields, out number);
            } else {
                return false;
            }
        }

        private static bool TryCreateNumber(string[] input, out Number number) {
            if(Int32.TryParse(input[1], out int result)) {
                number = new Number(input[0], result);
                return true;
            } else {
                number = null;
                return false;
            }
        }

        private static bool TryCreateNumberWithTimeout(string[] input, out Number number) {
            if(Int32.TryParse(input[1], out int baseNumber) && Int32.TryParse(input[2], out int timeout)) {
                number = new Number(input[0], baseNumber, timeout);
                return true;
            } else {
                number = null;
                return false;
            }
        }

    }
}
