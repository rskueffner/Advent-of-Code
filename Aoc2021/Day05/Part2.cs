using System;

namespace Aoc2021.Day05
{
    public class Part2 : Part1
    {
        public Part2(String input) : base(input) { }

        public override Int32 Solve()
        {
            return this.Solve(false);
        }
    }
}