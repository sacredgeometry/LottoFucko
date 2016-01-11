using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryChecker
{
    public class NumberCache
    {
        public Dictionary<string, List<int>> Tickets { get; set; }
        public enum WinTypes
        {
            LuckyDip = 2,
            ThreeBalls = 3,
            FourBalls = 4,
            FiveBalls = 5,
            Jackpot = 6,
            BonusBall = 7
        }

        public NumberCache ()
        {
            Tickets = new Dictionary<string, List<int>>()
            {
                { "Felinesoft_1A", new List<int>(){ 11,17,22,31,53,59 } },
                { "Felinesoft_1B", new List<int>(){ 1,12,22,29,46,58 } },
                { "Felinesoft_1C", new List<int>(){ 6,7,14,39,42,53 } },
                { "Felinesoft_1D", new List<int>(){ 18,21,25,36,44,50 } },
                { "Felinesoft_1E", new List<int>(){ 9,17,27,32,45,59 } },
                   
                { "Felinesoft_2A", new List<int>(){ 2,17,20,26,28,33 } },
                { "Felinesoft_2B", new List<int>(){ 6,24,34,44,45,49 } },
                { "Felinesoft_2C", new List<int>(){ 29,33,40,41,43,53 } },
                { "Felinesoft_2D", new List<int>(){ 29,35,39,42,43,57 } },
                   
                { "Felinesoft_3A", new List<int>(){ 6,8,10,40,41,51 } },
                { "Felinesoft_3B", new List<int>(){ 20,31,35,42,47,48 } },
                { "Felinesoft_3C", new List<int>(){ 13,17,38,41,46,56 } },
                { "Felinesoft_3D", new List<int>(){ 26,39,40,51,54,58 } },
                { "Felinesoft_3E", new List<int>(){ 6,33,36,37,49,58 } },
                   
                { "Felinesoft_4A", new List<int>(){ 13,21,26,27,33,44 } },
                { "Felinesoft_4B", new List<int>(){ 9,11,22,23,31,38 } },
                { "Felinesoft_4C", new List<int>(){ 2,7,22,29,36,58 } },
                { "Felinesoft_4D", new List<int>(){ 4,7,23,31,39,46 } },
                { "Felinesoft_4E", new List<int>(){ 3,25,30,36,44,59 } },
                   
                { "Felinesoft_5A", new List<int>(){ 10,11,14,18,29,54 } },
                { "Felinesoft_5B", new List<int>(){ 22,44,45,54,58,59 } },
                { "Felinesoft_5C", new List<int>(){ 3,6,25,29,41,51 } },
                { "Felinesoft_5D", new List<int>(){ 5,6,19,25,37,54 } },
                { "Felinesoft_5E", new List<int>(){ 5,11,35,54,56,57 } },
                   
                { "Felinesoft_6A", new List<int>(){ 12,13,30,33,44,56 } },
                { "Felinesoft_6B", new List<int>(){ 6,11,17,20,57,59 } },
                { "Felinesoft_6C", new List<int>(){ 10,13,20,22,23,59 } },
                { "Felinesoft_6D", new List<int>(){ 4,6,26,38,40,56 } },

                { "MyTickets_A", new List<int>(){ 7,24,52,56,57,59 } },
                { "MyTickets_B", new List<int>(){ 8,13,14,15,24,46 } },
                { "MyTickets_C", new List<int>(){ 1,12,16,39,51,56 } },
                { "MyTickets_D", new List<int>(){ 1,2,14,20,37,52 } },
                { "MyTickets_E", new List<int>(){ 3,7,11,20,33,49 } },
            };
        }

        public Dictionary<string, string> GetResults (List<int> winningNumbers, int bonusBall)
        {
            var output = new Dictionary<string, string>();

            foreach (var ticket in Tickets)
            {
                try
                {
                    string message = string.Empty;
                    var winNumber = ticket.Value.Intersect(winningNumbers).Count();
                    winNumber = IsBonusBall(winNumber, ticket, bonusBall) ? 7 : winNumber;  
                    var type = (WinTypes)winNumber;
                    bool log = true;

                    switch (type)
                    {
                        case WinTypes.LuckyDip:
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            message = "You have won a lucky dip!";
                            break;
                        case WinTypes.ThreeBalls:
                            // £25
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            message = "You have won £25!";
                            break;
                        case WinTypes.FourBalls:
                            //approx £100
                            Console.ForegroundColor = ConsoleColor.Green;
                            message = "You have won £100 (approx)!";
                            break;
                        case WinTypes.FiveBalls:
                            // approx £1000
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            message = "You have won £1000 (approx)!";
                            break;
                        case WinTypes.Jackpot:
                            // Jackpot                            
                            Console.ForegroundColor = ConsoleColor.White;
                            message = "You have won the jackpot!";
                            break;
                        case WinTypes.BonusBall:
                            // 5 and the bonus ball £50,000
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            message = "You have won the bonus ball, £50,000 (approx)!";
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            message = "You didnt win on this ticket!";
                            log = false;
                            break;
                    }

                    if (log) Console.WriteLine(string.Format("({1}) {0} ({3}) {2}", message, ticket.Key, System.Environment.NewLine, string.Join(", ", ticket.Value.OrderBy(x => x))));
                    output.Add(ticket.Key, string.Format("{0}", message ?? string.Empty));
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }

            return output;
        }

        private bool IsBonusBall(int amountOfNumbers, KeyValuePair<string, List<int>> ticket, int bonusBall)
        {
            if (amountOfNumbers == 5 && ticket.Value.Contains(bonusBall))
            {
                return true;
            }
            
            return false;
        }

    }
}
