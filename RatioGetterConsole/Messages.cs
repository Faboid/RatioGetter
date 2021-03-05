using System;
using System.Collections.Generic;
using System.Text;

namespace RatioGetterConsole {
    public static class Messages {

        public static string separator => "-----------------------------------------------------------------------";

        public static void ShowStartMessage() {
            Console.WriteLine("Insert a list of values following the standard format, then write \"Done\" to calculate the result.");
            ShowFormat();
        }

        public static void ShowFormat() {
            Console.WriteLine();
            Console.WriteLine("Standard format:");
            Console.WriteLine(separator);
            Console.WriteLine("[name] [value] [timeout value]");
            Console.WriteLine();
            Console.WriteLine("Only positive values. Max size: 4,294,967,295.");
            Console.WriteLine();
            Console.WriteLine("Note: the timeout value is optional.");
            Console.WriteLine("It's used to limit the maximum size of the multiplying factor.");
            Console.WriteLine(separator);
            Console.WriteLine();
        }

        public static void WriteLines(List<string> lines) {
            Console.WriteLine(separator);
            foreach(string line in lines) {
                Console.WriteLine(line);
            }
            Console.WriteLine(separator);
        }

    }
}
