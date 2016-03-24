using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _03.Softuni_Numerals
{
    class SoftuniNumerals
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"(aa)|(aba)|(bcc)|(cc)|(cdc)";
            MatchCollection matches = Regex.Matches(input, pattern);
            string numeric = FindMatches(matches);
            BigInteger number = ConvertToDecimal(numeric);
            Console.WriteLine(number);
        }

        private static string FindMatches(MatchCollection matches)
        {
            string numeralString;
            string numeric = string.Empty;

            foreach (Match match in matches)
            {
                numeralString = match.Value;

                switch (numeralString)
                {
                    case "aa":
                        numeric += 0;
                        break;
                    case "aba":
                        numeric += 1;
                        break;
                    case "bcc":
                        numeric += 2;
                        break;
                    case "cc":
                        numeric += 3;
                        break;
                    case "cdc":
                        numeric += 4;
                        break;
                }
            }

            return numeric;
        }

        private static BigInteger ConvertToDecimal(string numeric)
        {
            BigInteger result = 0;

            for (int i = numeric.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(numeric[i].ToString());
                result += BigInteger.Pow(5, numeric.Length - 1 - i) * digit;
            }

            return result;
        }
    }
}
