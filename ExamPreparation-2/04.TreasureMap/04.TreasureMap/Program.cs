using System;
using System.Text.RegularExpressions;

namespace _04.TreasureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern =
                @"((?<hash>#)|!)[^!#]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^!#]*(?<!\d)(?<streetNumber>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^!#]*?(?(hash)!|#)";
            var regex = new Regex(pattern);

            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine();
                var matches = regex.Matches(input);
                var match = matches[matches.Count / 2];
                var streetName = match.Groups["streetName"].Value;
                var streetNumber = match.Groups["streetNumber"].Value;
                var password = match.Groups["password"].Value;
                Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
            }
        }
    }
}
