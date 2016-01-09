using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryChecker
{
    class Program
    {
        public static void WriteWithColour (string input, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(input);
            Console.ResetColor();
        }

        public static bool IsWithinRange (int number)
        {
            if (number >= 1 && number <= 59)
            {
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            var numberCache = new NumberCache();

            List<int> winningNumbers = new List<int>();
            int bonusBall = 0;
            string failedComment = "You have entered bullshit! Try again!";

            do
            {
                Console.ResetColor();

                try
                {
                    Console.WriteLine("Please enter the winning lottery numbers (comma delimited) ...");
                    var numbers = Console.ReadLine().Split(',');
                    winningNumbers = numbers.Select(n => int.Parse(n)).ToList();

                    if (winningNumbers.Distinct().Count() != 6 || !winningNumbers.All(x => IsWithinRange(x)))
                    {
                        WriteWithColour(failedComment, ConsoleColor.DarkRed);
                        continue;
                    }

                    Console.WriteLine("Please enter the the bonus ball ...");
                    bonusBall = int.Parse(Console.ReadLine());

                    if(!(IsWithinRange(bonusBall) && !winningNumbers.Contains(bonusBall)))
                    {
                        WriteWithColour(failedComment, ConsoleColor.DarkRed);
                        bonusBall = 0;
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    WriteWithColour(failedComment, ConsoleColor.DarkRed);
                }
            } while (winningNumbers.Count < 6 || bonusBall == 0);

            string line = "-------------------------";
            Console.WriteLine(string.Format("{0} {1} [ Compooting Numbs ] {1} {0}", System.Environment.NewLine, line));

            var results = numberCache.GetResults(winningNumbers, bonusBall);

            Console.ReadLine();
        }
    }
}
