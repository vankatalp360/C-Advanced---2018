using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"\[[A-Za-z]+<(\d+)REGEH(\d+)>[A-Za-z]+]*");
            var indexes = new List<int>();
            var text = new StringBuilder();

            var matches = regex.Matches(input);
            var sum = 0;

            foreach (Match match in matches)
            {
                var firstNumber = sum += int.Parse(match.Groups[1].Value);
                var secondNumber = sum += int.Parse(match.Groups[2].Value);
                indexes.Add(firstNumber);
                indexes.Add(secondNumber);
            }

            foreach (var index in indexes)
            {
                var newIndex = index;
                if (index >= input.Length)
                {
                    newIndex = input.Length - 1 % index;
                }
                var character = input[newIndex];
                text.Append(character);
            }

            Console.WriteLine(text);
        }
    }
}
