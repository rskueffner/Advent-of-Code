using System;
using System.Linq;

namespace Aoc2021.Day06
{
    public class Part2 : Part1
    {
        public Part2(String input) : base(input)
        { }

        public override void Solve()
        {
            for (var d = 1; d <= 256; d++) { Reproduce(d); }

            Console.WriteLine(this.lanterns.Sum());
        }
    }
}