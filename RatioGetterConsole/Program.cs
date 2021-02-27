using System;
using System.Collections.Generic;
using System.Linq;
using RatioGetterLibrary;
using static RatioGetterConsole.Messages;

namespace RatioGetterConsole {
    class Program {
        static void Main(string[] args) {

            List<Number> nums = GetValues();

            var lines = nums.GetRatios();

            WriteLines(lines);

            Console.WriteLine("Press any key to close the console.");
            Console.ReadKey();
        }

        private static List<Number> GetValues() {
            List<Number> output = new List<Number>();
            ShowStartMessage();

            string line;
            while((line = Console.ReadLine()).ToUpper() != "DONE") {
                if(Converter.TryParseToNumber(line, out Number num)) {
                    output.Add(num);
                    Console.WriteLine("Added one value to the list.");
                    Console.WriteLine();
                } else {
                    Console.WriteLine("Invalid format.");
                    ShowFormat();
                }
            }

            return output;
        }



    }
}
