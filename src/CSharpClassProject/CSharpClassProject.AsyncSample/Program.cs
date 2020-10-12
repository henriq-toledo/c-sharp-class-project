using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace CSharpClassProject.AsyncSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Async sample");

            var numbers = Enumerable.Range(1, 10).ToArray();

            Sync(numbers);
            Async(numbers);

            Console.ReadLine();
        }

        static void Sync(int[] numbers)
        {
            Console.WriteLine();
            Console.WriteLine("Start Sync");

            var stopWatch = new Stopwatch();

            stopWatch.Start();

            foreach (var number in numbers)
            {
                Show(number);
            }

            stopWatch.Stop();

            Console.WriteLine($"Sync: {stopWatch.Elapsed.TotalSeconds} seconds");
        }

        static void Async(int[] numbers)
        {
            Console.WriteLine();
            Console.WriteLine("Start Async");

            var stopWatch = new Stopwatch();

            stopWatch.Start();

            numbers.AsParallel().ForAll(number => Show(number));

            stopWatch.Stop();

            Console.WriteLine($"Async: {stopWatch.Elapsed.TotalSeconds} seconds");
        }

        static void Show(int number)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine(number);
        }
    }
}
