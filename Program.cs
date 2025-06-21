//Use the code in this class to prove that the SplitMix64 PRNG implemented is 
//indeed correct and intractaable as described in Task 2 of the Assignment Brief

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DSA___A2___Part_Soution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            SplitMix64 prng = new SplitMix64();

            Console.WriteLine("=== PRNG Correctness Check ===");

            List<ulong> randomNumbers = new List<ulong>();

            for (int i = 0; i < 100; i++)
            {
                ulong num = prng.Next(1, 1000);
                randomNumbers.Add(num);
            }


            bool allInRange = randomNumbers.All(n => n >= 1 && n <= 1000);
            Console.WriteLine("All numbers in range 1-1000: " + allInRange);

            bool isAscending = randomNumbers.SequenceEqual(randomNumbers.OrderBy(n => n));
            Console.WriteLine("Numbers NOT sorted in ascending order: " + !isAscending);


            bool isDescending = randomNumbers.SequenceEqual(randomNumbers.OrderByDescending(n => n));
            Console.WriteLine("Numbers NOT sorted in descending order: " + !isDescending);

            Console.WriteLine();

            Console.WriteLine("=== PRNG Intractability Check ===");

            ulong[] sizes = { 1000, 10000, 100000, 1000000 };

            foreach (ulong size in sizes)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                for (ulong i = 0; i < size; i++)
                {
                    prng.Next(1, 1000);
                }

                sw.Stop();
                Console.WriteLine($"Generated {size} numbers in {sw.ElapsedMilliseconds} ms");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
