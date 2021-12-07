using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2021.Day07
{
    public class Part2 : Part1
    {
        public Part2(String input) : base(input)
        { }

        public override Int32 Cost(Int32 destination, Int32 origin)
        {
            var cost = base.Cost(destination, origin);

            return cost * (cost + 1) / 2;
        }

        public override void Solve()
        {
            var min = this.positions.Keys.Min();
            var max = this.positions.Keys.Max();

            var outcomes = new Dictionary<Int32, Int32>();
            foreach (var destination in Enumerable.Range(min, max))
            {
                outcomes.Add(destination, default);
            }

            foreach (var destination in outcomes.Keys)
            foreach (var position in this.positions)
            {
                outcomes[destination] += Cost(destination, position.Key) * position.Value;
            }

            Console.WriteLine(outcomes.Values.Min());
        }
    }
}