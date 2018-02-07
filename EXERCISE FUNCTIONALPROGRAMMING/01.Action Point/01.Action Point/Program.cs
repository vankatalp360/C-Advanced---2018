using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> Print = x => Console.WriteLine(x);

            foreach (var name in names)
            {
                Print(name);
            }
        }
    }
}
