using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var lenght = int.Parse(Console.ReadLine());
            if (lenght < 1)
            {
                Environment.Exit(0);
            }
            var numbers = Enumerable.Range(1, Math.Abs(lenght));

            var divisors = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToList();

            var Filter = CreaterFilter(divisors);

            numbers = numbers.Where(Filter).ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }

        static Func<int, bool> CreaterFilter(List<int> divisors)
        {
            return num =>
            {
                foreach (var divisor in divisors)
                {
                    if (num % Math.Abs(divisor) != 0)
                    {
                        return false;
                    }
                }
                return true;
            };
        }
    }
}
