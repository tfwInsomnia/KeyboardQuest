using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG {
    public static class EntryManager {

        public static string numbers = "0123456789";
        
        public static bool IsDigitsOnly(string str) {
            foreach (char c in str) {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public static int Entry( int upperLimit, int LlowerLimit = 0) {
            string input = Console.ReadLine();
            bool good = Acceptable(str: input, upLim: upperLimit, lowLim: LlowerLimit);

            while (!good) {
                input = Console.ReadLine();
                good = Acceptable(str: input, upLim: upperLimit, lowLim: LlowerLimit);
            }
            return Int32.Parse(input);
        }


        public static bool Acceptable(string str, int upLim, int lowLim=0) {
            foreach (char c in str) {
                if (!numbers.Contains(c)) {

                    Console.WriteLine($"Invalid entry, enter numbers only");
                    return false;
                }
            }
                if (String.IsNullOrEmpty(str)) {
                return false ;
            }
            int n = Int32.Parse(str);
            if(n<lowLim || n > upLim) {
                Console.WriteLine($"Invalid entry, enter {lowLim}-{upLim}");
                return false;
            }

            return true;
        }

    }
}
