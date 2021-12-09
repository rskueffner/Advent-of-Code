using System;

namespace Aoc2021.Day07
{
    public class Part2 : Part1
    {
        public Part2(String input) : base(input) { }

        public override Int32 Cost(Int32 destination, Int32 origin)
        {
            var cost = base.Cost(destination, origin);

            return cost * (cost + 1) / 2;
        }
    }
}