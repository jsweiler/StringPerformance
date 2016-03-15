using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPerformanceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //get things jitted properly
            UseStringFormat(10000);
            UseStringInterpolation(10000);
            UseStringConcat(10000);
            UseStringFormat(10000);
            UseStringInterpolation(10000);
            UseStringConcat(10000);

            var stopFormat = Stopwatch.StartNew();
            UseStringFormat(1000000);
            stopFormat.Stop();
            Console.WriteLine($"String format time: {stopFormat.Elapsed}");

            var stopInterpolation = Stopwatch.StartNew();
            UseStringInterpolation(1000000);
            stopInterpolation.Stop();
            Console.WriteLine($"String interpolation time: {stopInterpolation.Elapsed}");

            var stopConcat = Stopwatch.StartNew();
            UseStringConcat(1000000);
            stopConcat.Stop();
            Console.WriteLine($"String concatentation time: {stopConcat.Elapsed}");

            Console.ReadKey();
        }

                public static void UseStringFormat(int number)
        {
            var random = new Random();
            var text = "";
            for (var i = 0; i <= number; i++)
            {
                text = string.Format("First string {0} second string {0}", random.Next(i, i + 1000), i);
            }
        }

        public static void UseStringInterpolation(int number)
        {
            var random = new Random();
            //var array = new string[number + 1];v
            var text = "";
            for (var i = 0; i <= number; i++)
            {
                text = $"First string {random.Next(i, i + 1000)} second string {i}";
            }
        }

        public static void UseStringConcat(int number)
        {
            var random = new Random();
            //var array = new string[number + 1];
            var text = "";
            for (var i = 0; i <= number; i++)
            {
                text = "First string " + random.Next(i , i + 1000) + " second string " + i;
            }
        }
    }
}
