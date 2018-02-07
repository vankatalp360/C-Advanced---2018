using System;
using System.Linq;

namespace _08._CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var evenNumbers = numbers.Where(n => n % 2 == 0).OrderBy(n => n).ToList();
            var oddNumbers = numbers.Where(n => n % 2 != 0).OrderBy(n => n).ToList();

            evenNumbers.AddRange(oddNumbers);

            Console.WriteLine(string.Join(" ", evenNumbers));

        }
    }
}
