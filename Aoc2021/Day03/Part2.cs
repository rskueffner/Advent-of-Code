using System;
using System.Linq;

namespace Aoc2021.Day03
{
    public class Part2 : Part1
    {
        public Part2(String input) : base(input) { }

        public override Int32 Solve()
        {
            var generatorReports = this.numbers;
            for (var i = this.bits; 0 <= i; i--)
            {
                var bit = Part1.MostCommonBit(i, generatorReports);

                generatorReports = generatorReports
                    .Where(r => Part1.GetBit(i, r) == bit)
                    .ToList();
            }

            var scrubberReports = this.numbers;
            for (var i = this.bits; 0 <= i; i--)
            {
                var bit = Part1.LeastCommonBit(i, scrubberReports);

                scrubberReports = scrubberReports
                    .Where(r => Part1.GetBit(i, r) == bit)
                    .ToList();
            }

            var generatorRating = generatorReports.Single();
            var scrubberRating = scrubberReports.Single();

            return generatorRating * scrubberRating;
        }
    }
}