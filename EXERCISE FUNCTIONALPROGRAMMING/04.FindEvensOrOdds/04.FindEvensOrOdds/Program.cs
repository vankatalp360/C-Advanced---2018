using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var rangeParts = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var format = Console.ReadLine();

            Action<List<int>> PrintNumbers = x => Console.WriteLine(string.Join(" ", x));

            var start = rangeParts[0];
            var range = rangeParts[1] - rangeParts[0] + 1;
            var numbers = Enumerable.Range(start, range).ToList();

            var creater = CreateNewList(format);

            var result = creater(numbers);

            PrintNumbers(result);
        }

        static Func<List<int>, List<int>> CreateNewList(string format)
        {
            if (format.ToLower() == "even")
            {
                return x => x.Where(n => n % 2 == 0).ToList();
            }
            return x => x.Where(n => n % 2 != 0).ToList();
        }
    }
}
