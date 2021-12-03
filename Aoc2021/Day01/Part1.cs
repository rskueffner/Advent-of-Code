using System;
using System.Collections.Generic;

namespace Aoc2021.Day01
{
    public class Part1 : Aoc.Part
    {
        public Part1(String input) : base(input)
        {
            this.measurements = new List<Int32>();

            var lines = this.input.Split(Environment.NewLine);
            foreach (var line in lines)
            {
                var measurement = Int32.Parse(line);

                this.measurements.Add(measurement);
            }
        }

        protected readonly IList<Int32> measurements;

        public static IList<Int32> CalculateDifferences(IList<Int32> measurements)
        {
            var differences = new List<Int32>();
            for (var i = 1; i < measurements.Count; ++i)
            {
                var difference = measurements[i] - measurements[i - 1];

                differences.Add(difference);
            }

            return differences;
        }

        public static Int32 CountIncreases(IList<Int32> differences)
        {
            var count = 0;
            foreach (var difference in differences)
            {
                if (0 < difference) { ++count; }
            }

            return count;
        }

        public override void Solve()
        {
            var differences = CalculateDifferences(this.measurements);
            var increases = CountIncreases(differences);

            Console.WriteLine(increases);
        }
    }
}
