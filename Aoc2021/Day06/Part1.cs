using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2021.Day06
{
    public class Part1 : Aoc.Part
    {
        public Part1(String input) : base(input)
        {
            this.lanterns = new Int64[9];

            var rates = this.input.Split(',');
            foreach (var rate in rates)
            {
                var lifecycle = Convert.ToInt32(rate);

                this.lanterns[lifecycle] += 1;
            }
        }

        protected Int64[] lanterns;

        private void Reproduce(Int32 day)
        {
            if (day == 0) { return; }

            Reproduce(day - 1);

            Int32 offset(Int32 index) => (day + index) % 9;

            this.lanterns[offset(6)] += this.lanterns[offset(8)];
        }

        public override void Solve()
        {
            Reproduce(256);

            Console.WriteLine(this.lanterns.Sum());
        }
    }
}