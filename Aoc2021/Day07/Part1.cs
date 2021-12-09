using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2021.Day07
{
    public class Part1 : Aoc.Part<Int32>
    {
        public Part1(String input) : base(input)
        {
            this.positions = new Dictionary<Int32, Int32>();

            var positions = input.Split(',');
            foreach (var position in positions)
            {
                var value = Convert.ToInt32(position);

                if (!this.positions.ContainsKey(value))
                {
                    this.positions.Add(value, default); 
                }

                this.positions[value] += 1;
            }
        }

        protected IDictionary<Int32, Int32> positions;

        public virtual Int32 Cost(Int32 destination, Int32 origin)
        {
            return Math.Abs(destination - origin);
        }

        public override Int32 Solve()
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

            return outcomes.Values.Min();
        }
    }
}