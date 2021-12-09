using System;
using System.Linq;

namespace Aoc2021.Day06
{
    public class Part1 : Aoc.Part<Int64>
    {
        public Part1(String input) : base(input)
        {
            this.lanterns = new Int64[9];

            var rates = input.Split(',');
            foreach (var rate in rates)
            {
                var lifecycle = Convert.ToInt32(rate);

                this.lanterns[lifecycle] += 1;
            }
        }

        protected Int64[] lanterns;

        protected void Reproduce(Int32 day)
        {
            if (day == 0) { return; }

            Int32 offset(Int32 index) => (day + index) % 9;

            this.lanterns[offset(6)] += this.lanterns[offset(8)];
        }

        protected Int64 Population(Int32 generation)
        {
            for (var d = 1; d <= generation; d++) { Reproduce(d); }

            return this.lanterns.Sum();
        }

        public override Int64 Solve()
        {
            return this.Population(80);
        }
    }
}