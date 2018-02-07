using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var command = Console.ReadLine().ToLower();
            Action<List<int>> Print = x => Console.WriteLine(string.Join(" ", x));

            while (command != "end")
            {
                if (command == "print")
                {
                    Print(numbers);
                    command = Console.ReadLine().ToLower();
                    continue;
                }

                var operation = CreateOperation(command);

                numbers = numbers.Select(n => operation(n)).ToList();


                command = Console.ReadLine().ToLower();
            }

        }

        static Func<int, int> CreateOperation(string command)
        {
            if (command == "add")
            {
                return x => x + 1;
            }
            else if(command == "multiply")
            {
                return x => x * 2;
            }
            else if(command == "subtract")
            {
                return x => x - 1;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
