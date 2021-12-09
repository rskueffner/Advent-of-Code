using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2021.Day08
{
    public class Part1 : Aoc.Part<Int32>
    {
        public Part1(String input) : base(input)
        {
            this.entries = new List<String[]>();

            var lines = input.Split(Environment.NewLine);
            foreach (var line in lines)
            {
                var entry = line
                    .Replace(" | ", " ")
                    .Split(" ")
                    .Select(s => new String(s.OrderBy(c => c).ToArray()))
                    .ToArray();
                
                this.entries.Add(entry);
            }
        }

        protected readonly IList<String[]> entries;

        public override Int32 Solve()
        {
            var total = 0;

            foreach (var entry in this.entries)
            foreach (var display in entry[^4..])
            switch (display.Length)
            {
                case 2: // One
                case 4: // Four
                case 3: // Seven
                case 7: // Eight
                    total += 1;
                    break;
                        
                default:
                    break;
            }

            return total;
        }
    }
}