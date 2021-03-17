using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AsParallelDemoHakan
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Diagnostics.Stopwatch

            int number = 2056879456;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool prime = IsPrimeNumber(number);
            Console.WriteLine($"{number} is a prime number: {prime}");
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds / 1000.0} seconds");
            stopwatch.Stop();

            HeavyWork();

        }

        private static void HeavyWork()
        {
            List<int> primeNumbers = new List<int>
            {
                8, // not prime number
                50011063,
                1000004100, // not prime number
                1000005133,
                10009729,
                150011297,
                1000012253,
                1000009831,
                1000004099,
                150006809,

            };

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var q = primeNumbers
                .AsParallel() // Nice sstuff - gör beräkningarna asynkrona.
                .Select(p => $"{p} is a prime number: {IsPrimeNumber(p)}");

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }

            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds / 1000} seconds");

        }

        public static bool IsPrimeNumber(int wholeNumber)
        {
            int i;

            for (i = 2; i <= wholeNumber - 1; i++)
            {
                if (wholeNumber % i == 0)
                    return false;
            }

            if (i == wholeNumber)
                return true;

            return false;
        }
    }
}
