using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"(\[([^\d]*)(?<digits>\d{3,})([^\d]*)])|({([^\d]*)(?<digits>\d{3,})([^\d]*)})";
            var regex = new Regex(pattern);
            var block = "";
            var lines = int.Parse(Console.ReadLine());
            var word = new StringBuilder();

            for (int i = 0; i < lines; i++)
            {
                var line = Console.ReadLine();
                block += line;
            }

            var matches = regex.Matches(block);

            foreach (Match match in matches)
            {
                var digits = match.Groups["digits"].ToString().ToCharArray();
                if (digits.Length % 3 != 0)
                {
                    continue;
                }

                for (int i = 0; i < digits.Length; i +=3)
                {
                    var blockLenght = match.Length;
                    var firstNumber = digits[i];
                    var secondNumber = digits[i + 1];
                    var thirdNumber = digits[i + 2];
                    var str = firstNumber + "" + secondNumber + "" + thirdNumber;
                    var number = int.Parse(str);
                    word.Append((char) (number - blockLenght));
                }
            }

            Console.WriteLine(word);
        }
    }
}
