using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadersStatistics
{
    public class Program
    {
        static void Main(string[] args)
        {
            HeaderCharactersCalculator calculator = new HeaderCharactersCalculator();

            var timer = new System.Threading.Timer(
                e => calculator.Run(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromMinutes(10));

            Console.ReadKey();
        }
    }
}
