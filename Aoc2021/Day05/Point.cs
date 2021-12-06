using System;

namespace Aoc2021.Day05
{
    public record Point(Int32 X, Int32 Y)
    {
        public static Point Deserialize(String input)
        {
            var coordinates = input.Split(",");

            var x = Convert.ToInt32(coordinates[0]);
            var y = Convert.ToInt32(coordinates[1]);

            return new Point(x, y);
        }
    };
}
