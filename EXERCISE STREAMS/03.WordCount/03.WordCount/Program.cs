using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsFrequency = new Dictionary<string, int>();
            var words = new List<string>();

            using (var reader = new StreamReader("../../Resources/words.txt"))
            {
                var word = reader.ReadLine();
                while (word != null)
                {
                    wordsFrequency[word.ToLower()] = 0;
                    words.Add(word);
                    word = reader.ReadLine();
                }
            }

            var text = string.Empty;

            using (var reader = new StreamReader("../../Resources/text.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    text += line.ToLower();
                    line = reader.ReadLine();
                }
            }

            foreach (var word in words)
            {
                string[] ws = text
                    .Split(" .,?!:;-[]{}()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                foreach (var w in ws)
                {
                    if (w == word)
                    {
                        wordsFrequency[word]++;
                    }   
                }

            }

            using (var writer = new StreamWriter("../../result.txt"))
            {
                var result = wordsFrequency.OrderByDescending(w => w.Value).ToDictionary(x => x.Key, y => y.Value);

                foreach (var word in result)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
