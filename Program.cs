using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryChecker
{
    class Program
    {
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

                    if (winningNumbers.Count != 6)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(failedComment);
                        continue;
                    }

                    Console.WriteLine("Please enter the the bonus ball ...");
                    bonusBall = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(failedComment);
                }
            } while (winningNumbers.Count < 6 || bonusBall == 0);

            string line = "-------------------------";
            Console.WriteLine(string.Format("{0} {1} [ Compooting Numbs ] {1} {0}", System.Environment.NewLine, line));

            var results = numberCache.GetResults(winningNumbers, bonusBall);

            Console.ReadLine();
        }
    }
}
