using System;
using System.Linq;

namespace _13.TriFinction
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var result = names.FirstOrDefault(name => name.ToCharArray().Sum(c => c) >= sum);
            Console.WriteLine(result);
        }
        
    }
}
