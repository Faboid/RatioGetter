using System;
using System.Collections.Generic;
using System.Linq;
using RatioGetterLibrary;
using static RatioGetterConsole.Messages;

namespace RatioGetterConsole {
    class Program {
        static void Main(string[] args) {

            SetUp(out uint approx, out ulong limit);

            do {
                EvaluateRatioRound(approx, limit);
            } while(AskIfContinue());

            Console.WriteLine("Press any key to close the console.");
            Console.ReadKey();
        }

        private static bool AskIfContinue() {
            Console.WriteLine("Want to continue? Y/N");
            return Console.ReadKey().ToString().ToUpper() != "N";
        }

        private static void EvaluateRatioRound(uint approx, ulong limit) {
            Console.WriteLine();
            List<Number> nums = GetValues();
            //var lines = nums.GetRatios(approx, limit);
            Ratioer ratio = new Ratioer(nums, approx, limit);
            var lines = ratio.GetRatios();

            WriteLines(lines);
        }

        private static void SetUp(out uint approx, out ulong limit) {
            Console.WriteLine("If you want an approximated ratio(useful for non-meeting numbers), please give a number. If you don't, set 0.");
            approx = GetInputValue();

            Console.WriteLine("If you want to change the default max attempts, please give a number. To use the default value, set 0.");
            limit = GetInputValue();
        }

        private static uint GetInputValue() {
            while(true) {
                var line = Console.ReadLine();

                if(UInt32.TryParse(line, out uint num)) {
                    return num;
                } else {
                    Console.WriteLine("Only numeric values are allowed.");
                }
            }
        }

        private static List<Number> GetValues() {
            List<Number> output = new List<Number>();
            ShowStartMessage();

            string exitLine = "DONE";
            while(GetLine(exitLine, out string line)) {
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

        private static bool GetLine(string exit, out string line) {
            return (line = Console.ReadLine()).ToUpper() != exit.ToUpper();
        }


    }
}
