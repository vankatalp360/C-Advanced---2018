using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var input = Console.ReadLine();

            while (input != "Party!")
            {
                var parts = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var command = parts[0];
                var criterion = parts[1];

                switch (command)
                {
                    case "Remove": RemoveGuest(names, criterion, parts[2]);
                        break;
                    case "Double": DoubleGuest(names, criterion, parts[2]);
                        break;
                }

                input = Console.ReadLine();
            }

            Print(names);
        }

        private static void Print(List<string> names)
        {
            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void DoubleGuest(List<string> names, string criterion, string pattern)
        {
            var filterGuests = FilterGuests(names, criterion, pattern);

            for (int i = 0; i < names.Count; i++)
            {
                for (int j = 0; j < filterGuests.Count; j++)
                {
                    if (names[i] == filterGuests[j])
                    {
                        names.Insert(i++, filterGuests[j]);
                        break;
                    }
                }
            }
        }

        private static void RemoveGuest(List<string> names, string criterion, string pattern)
        {
            var filterGuests = FilterGuests(names, criterion, pattern);

            foreach (var guest in filterGuests)
            {
                if (names.Contains(guest))
                {
                    names.Remove(guest);
                }
            }

        }

        private static List<string> FilterGuests(List<string> names, string criterion, string pattern)
        {
            Predicate<string> startsWith = x => x.StartsWith(pattern);
            Predicate<string> endsWith = x => x.EndsWith(pattern);
            Predicate<string> Length = x => x.Length == int.Parse(pattern);

            var filterGuests = new List<string>();

            switch (criterion)
            {
                case "StartsWith":
                    filterGuests = names.Where(n => startsWith(n)).ToList();
                    break;
                case "EndsWith":
                    filterGuests = names.Where(n => endsWith(n)).ToList();
                    break;
                case "Length":
                    filterGuests = names.Where(n => Length(n)).ToList();
                    break;
            }
            return filterGuests;
        }

        
    }
}
