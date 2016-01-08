﻿using System;
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
            var results = numberCache.GetResults(new List<int>() { 11, 17, 22, 31, 53, 59 }, 1);

            Console.ReadLine();
        }
    }
}
