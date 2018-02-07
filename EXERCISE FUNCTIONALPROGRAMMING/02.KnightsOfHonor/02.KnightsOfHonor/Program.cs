using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> Print = x => Console.WriteLine($"Sir {x}");

            foreach (var name in names)
            {
                Print(name);
            }
        }
    }
}
