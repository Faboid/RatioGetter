using System;
using System.Collections.Generic;
using System.Linq;
using RatioGetterLibrary;
using static RatioGetterConsole.Messages;

namespace RatioGetterConsole {
    class Program {
        static void Main(string[] args) {

            SetUp(out uint approx, out long limit);

            do {
                EvaluateRatioRound(approx, limit);
            } while(AskIfContinue());

            Console.WriteLine("Press any key to close the console.");
            Console.ReadKey();
        }

        private static bool AskIfContinue() {
            Console.WriteLine("Want to continue? Y/N");
            string[] exits = new string[] { "N", "NO", "EXIT" };
            string command = Console.ReadLine().ToString().ToUpper();

            return !exits.Contains(command);
        }

        private static void EvaluateRatioRound(uint approx, long limit) {
            Console.WriteLine();
            List<Number> nums = GetValues();
            Ratioer ratio = new Ratioer(nums, approx, limit);
            var lines = ratio.GetRatios();

            WriteLines(lines);
        }

        private static void SetUp(out uint approx, out long limit) {
            Console.WriteLine("Performing initial setup...");
            Console.WriteLine("The next two values you assign will be immutable. To change them, reset the application.");
            Console.WriteLine();

            Console.WriteLine("If you want an approximated ratio(useful for never-meeting numbers), please give a positive number. Otherwise, set 0.");
            approx = GetInputValue();
            Console.WriteLine();

            Console.WriteLine("If you want to change the default max attempts, please give a number. To use the default value, set 0. To turn off the limit on attempts(warning: might result in an infinite loop), set a negative value.");
            limit = GetInputValue();
            Console.WriteLine();
        }

        private static uint GetInputValue() {
            while(true) {
                var line = Console.ReadLine();

                if(UInt32.TryParse(line, out uint num)) {
                    return num;
                } else {
                    Console.WriteLine("Only positive numeric values are allowed.");
                }
            }
        }

        private static List<Number> GetValues() {
            List<Number> output = new List<Number>();
            ShowStartMessage();

            string exitLine = "DONE";
            while(GetLine(exitLine, out string line)) {
                if(Number.TryParse(line, out Number num)) {
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
