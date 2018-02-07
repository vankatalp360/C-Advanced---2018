using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var lenght = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var Filter = CreateFilter(lenght);

            Action<List<string>> Print = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            names = Filter(names);

            Print(names);

        }

        static Func<List<string>, List<string>> CreateFilter(int number)
        {
            return x => x.Where(s => s.Length <= number).ToList();
        }
    }
}
