using System;
using System.Linq;

namespace _06.RemovesAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            numbers.Reverse();

            var number = int.Parse(Console.ReadLine());
            var Remover = CreateRemover(number);
            numbers.RemoveAll(x => Remover(x));

            Console.WriteLine(string.Join(" ", numbers));
        }

        static Func<int, bool> CreateRemover(int number)
        {
            return x => x % number == 0;
        }
        
    }
}
