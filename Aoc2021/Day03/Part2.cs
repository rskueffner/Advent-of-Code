using System;
using System.Linq;

namespace Aoc2021.Day03
{
    public class Part2 : Part1
    {
        public Part2(String input) : base(input)
        { }

        public override void Solve()
        {
            var length = this.numbers.First().Length;

            var oxygen = this.numbers;            
            for (var i = 0; i < length; i++)
            {
                var bit = MostCommonBit(i, oxygen);

                oxygen = oxygen.Where(n => n[i] == bit).ToList();
            }

            var carbonDioxide = this.numbers;
            for (var i = 0; i < length; i++)
            {
                var bit = LeastCommonBit(i, carbonDioxide);

                carbonDioxide = carbonDioxide.Where(n => n[i] == bit).ToList();
            }

            var generatorRating = BinaryToDecimal(oxygen.Single());
            var scrubberRating  = BinaryToDecimal(carbonDioxide.Single());

            var lifeSupportRating = generatorRating * scrubberRating;

            Console.WriteLine(lifeSupportRating);
        }
    }
}