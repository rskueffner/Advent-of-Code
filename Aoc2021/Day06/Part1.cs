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

        protected readonly Int64[] lanterns;

        private Int64[] Reproduce(Int64[] lanterns)
        {
            var initial = lanterns[0];

            for (var i = 0; i < lanterns.Length - 1; i++)
            {
                lanterns[i] = lanterns[i + 1];
            }

            lanterns[6] += initial;
            lanterns[8] = initial;

            return lanterns;
        }

        public override void Solve()
        {
            var population = this.lanterns;

            for (var day = 0; day < 256; day++)
            {
                population = Reproduce(population);
            }

            Console.WriteLine(population.Sum());
        }
    }
}