using System;
using System.Collections.Generic;

namespace Aoc2021.Day01
{
    public class Part2 : Part1
    {
        public Part2(String input) : base(input)
        { }

        public static IList<Int32> AggregateMeasurements(IList<Int32> measurements, Int32 windowSize = 3)
        {
            var aggregates = new List<Int32>();
            for (var i = 0; i < measurements.Count - (windowSize - 1); ++i)
            {
                var aggregate = 0;
                for (var w = 0; w < windowSize; ++w)
                {
                    aggregate += measurements[i + w];
                }

                aggregates.Add(aggregate);
            }

            return aggregates;
        }

        public override void Solve()
        {
            var aggregates = AggregateMeasurements(this.measurements);
            var differences = CalculateDifferences(aggregates);
            var increases = CountIncreases(differences);

            Console.WriteLine(increases);
        }
    }
}
