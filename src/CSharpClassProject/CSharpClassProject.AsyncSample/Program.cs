using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System.Text;

namespace CSharpClassProject.AsyncSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Async sample");

            var numbers = Enumerable.Range(1, 10).ToArray();

            Sync(numbers);
            Async(numbers);

            ReadFileSync();
            await ReadFileAsync();

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
    
        static void ReadFileSync()
        {
            Console.WriteLine();
            Console.WriteLine("Read Sync");

            var stopWatch = new Stopwatch();

            stopWatch.Start();

            File.ReadAllText(@"..\..\..\README.md");

            stopWatch.Stop();

            Console.WriteLine($"Read Sync: {stopWatch.Elapsed.TotalSeconds} seconds");
        }

        static async Task ReadFileAsync()
        {
            Console.WriteLine("Read Async");

            var stopWatch = new Stopwatch();

            stopWatch.Start();

            await File.ReadAllTextAsync(@"..\..\..\README.md");

            stopWatch.Stop();

            Console.WriteLine($"Read Async: {stopWatch.Elapsed.TotalSeconds} seconds");
        }
    }
}
