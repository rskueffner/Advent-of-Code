using System;

namespace Aoc2021.Day06
{
    public class Part2 : Part1
    {
        public Part2(String input) : base(input) { }

        public override Int64 Solve()
        {
            return this.Population(256);
        }
    }
}