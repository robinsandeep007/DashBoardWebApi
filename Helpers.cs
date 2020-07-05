using System;
using System.Collections.Generic;

namespace Advantage.API
{
    public static class Helpers
    {
        private static readonly Random _rand = new Random();
        private static string GetRandom(IList<string> items)
        {
            return items[_rand.Next(items.Count)];
        }

        internal static string MakeCustomerName(List<string> names)
        {
            var maxNames = bizPrefix.Count * bizSuffix.Count;
            if (names.Count >= maxNames)
            {
                throw new System.InvalidProgramException("Maximum number of unique name exceeded");
            }

            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSuffix);

            var bizName = prefix + suffix;
            if (names.Contains(bizName))
            {
                MakeCustomerName(names);
            }
            return bizName;
        }

        internal static string MakeCustomerEmail(string name)
        {
            return $"contact@{name.ToLower()}.com";
        }
        internal static string GetRandomState()
        {
            return GetRandom(usStates);
        }

        private static readonly List<string> usStates = new List<string>()
       {
           "AK", "AL", "AR", "AS", "AZ", "CA", "CO", "CT", "DC", "DE","FL", "GA",
           "GU", "HI", "IA", "ID", "IL", "IN", "KS", "KY", "LA", "MA","MD", "ME",
           "MI", "MN", "MO", "MP", "MS", "MT", "NC", "ND", "NE", "NH","NJ", "NM",
           "NV", "NY", "OH", "OK", "OR", "PA", "PR", "RI", "SC", "SD","TN", "TX",
           "UM", "UT", "VA", "VI", "VT", "WA", "WI", "WV", "WY"
       };

        private static readonly List<string> bizPrefix = new List<string>()
       {
           "abc",
           "xyz",
           "MainSt",
           "Scales",
           "Enterprise",
           "Ready",
           "Quick",
           "Budget",
           "Peek",
           "Magic",
           "Family",
           "stan"
       };


        private static readonly List<string> bizSuffix = new List<string>()
       {
           "Corp",
           "Co",
           "Inc",
           "Llc",
           "Solution",
           "Good",
           "Foods",
           "Cleaner",
           "Hotels",
           "Planners",
           "Autos",
           "Books"
       };

        internal static DateTime? GetRandomOrdercompleted(DateTime placed)
        {
            var now = DateTime.Now;
            var minLeadTime = TimeSpan.FromDays(7);
            var TimePassed = now - placed;
            if(TimePassed< minLeadTime)
            {
                return null;
            }
            return placed.AddDays(_rand.Next(7, 14));

        }

        internal static DateTime GetRandomOrderPlaced()
        {
            var end = DateTime.Now;
            var start = end.AddDays(-90);

            TimeSpan possibleTimeSpan = end - start;
            TimeSpan newTimeSpan = new TimeSpan(0, _rand.Next(0, (int)possibleTimeSpan.TotalMinutes), 0);

            return start + newTimeSpan;
        }

        internal static decimal GetRandomTotal()
        {
            return _rand.Next(100, 5000);
        }
    }
}