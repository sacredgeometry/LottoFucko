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

        public NumberCache ()
        {
            Tickets = new Dictionary<string, List<int>>()
            {
                { "1A", new List<int>(){ 11,17,22,31,53,59 } },
                { "1B", new List<int>(){ 1,12,22,29,46,58 } },
                { "1C", new List<int>(){ 6,7,14,39,42,53 } },
                { "1D", new List<int>(){ 18,21,25,36,44,50 } },
                { "1E", new List<int>(){ 9,17,27,32,45,59 } }
            };
        }

        public Dictionary<string, string> GetResults (List<int> winningNumbers, int luckyDip)
        {
            var output = new Dictionary<string, string>();

            foreach (var ticket in Tickets)
            {
                try
                {
                    var amountOfNumbers = ticket.Value.Intersect(winningNumbers).Count();
                    string message = string.Empty;

                    switch (amountOfNumbers)
                    {
                        case 2:
                            message = "You have won a lucky dip!";
                            break;
                        case 3:
                            // £25
                            message = "You have won £25!";
                            break;
                        case 4:
                            //approx £100
                            message = "You have won £100 (approx)!";
                            break;
                        case 5:
                            // approx £1000
                            message = "You have won £1000 (approx)!";
                            break;
                        case 6:
                            // Jackpot
                            // or 5 and bonus ball £50,000
                            message = "You have won either the jackpot or bonus ball (work this shit out)!";
                            break;
                        default:
                            message = "You didnt win on this ticket!";
                            break;
                    }

                    output.Add(ticket.Key, string.Format("{0}", message ?? string.Empty));
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }

            return output;
        }
    }
}
