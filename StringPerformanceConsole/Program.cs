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
            UseStringFormat(10000, "areallylongbiguglyextrasuperlongstring1", "areallylongbiguglyextrasuperlongstring2");
            UseStringInterpolation(10000, "areallylongbiguglyextrasuperlongstring1", "areallylongbiguglyextrasuperlongstring2");

            var stopFormat = Stopwatch.StartNew();
            UseStringFormat(5000000, "areallylongbiguglyextrasuperlongstring1", "areallylongbiguglyextrasuperlongstring2");
            stopFormat.Stop();
            Console.WriteLine($"String format time: {stopFormat.Elapsed}");

            var stopInterpolation = Stopwatch.StartNew();
            UseStringInterpolation(5000000, "areallylongbiguglyextrasuperlongstring1", "areallylongbiguglyextrasuperlongstring2");
            stopInterpolation.Stop();
            Console.WriteLine($"String interpolation time: {stopInterpolation.Elapsed}");

            Console.ReadKey();
        }

        public static void UseStringFormat(int number, string firstString, string secondString)
        {
            var array = new string[number + 1];
            for (var i = 0; i <= number; i++)
            {
                array[i] = string.Format("First string {0} second string {1}", firstString, secondString);
            }
        }

        public static void UseStringInterpolation(int number, string firstString, string secondString)
        {
            var array = new string[number + 1];
            for (var i = 0; i <= number; i++)
            {
                array[i] = $"First string {firstString} second string {secondString}";
            }
        }
    }
}
