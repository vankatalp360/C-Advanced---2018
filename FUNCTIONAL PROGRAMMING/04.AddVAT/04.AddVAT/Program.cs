using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleCount = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>(peopleCount);

            ReadPeople(peopleCount, people);

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            var filter = CreateFilter(condition, age);
            var printer = CreatePrint(format);

            foreach (var person in people)
            {
                if (filter(person))
                {
                    printer(person);
                }
            }
        }

        static Func<KeyValuePair<string, int>, bool> CreateFilter(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x.Value < age;
            }
            else
            {
                return x => x.Value >= age;
            }
        }

        static Action<KeyValuePair<string, int>> CreatePrint(string format)
        {
            switch (format)
            {
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                case "name":
                    return x => Console.WriteLine($"{x.Key}");
                case "age":
                    return x => Console.WriteLine($"{x.Value}");
                default: 
                    throw new NotImplementedException();
            }
        }
        private static void ReadPeople(int peopleCount, Dictionary<string, int> people)
        {
            for (int i = 0; i < peopleCount; i++)
            {
                var parts = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                var name = parts[0];
                var age = int.Parse(parts[1]);
                people[name] = age;
            }
        }
    }
}
