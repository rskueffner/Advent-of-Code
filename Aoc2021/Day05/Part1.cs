using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2021.Day05
{
    public class Part1 : Aoc.Part
    {
        public Part1(String input) : base(input)
        {
            this.segments = new List<Segment>();

            var lines = input.Split(Environment.NewLine);
            foreach (var line in lines)
            {
                var points = line.Split(" -> ");

                var start = Point.Deserialize(points[0]);
                var end = Point.Deserialize(points[1]);

                var segment = new Segment(start, end);

                this.segments.Add(segment);
            }
        }

        protected IList<Segment> segments;

        public override void Solve()
        {
            this.Solve(true);
        }

        protected void Solve(Boolean ignoreDiagonals)
        {
            var xMax = this.segments.Max(s => Math.Max(s.Start.X, s.End.X));
            var yMax = this.segments.Max(s => Math.Max(s.Start.Y, s.End.Y));

            var plane = new Int32[xMax + 1, yMax + 1];

            foreach (var segment in this.segments)
            {
                var x = segment.Start.X;
                var xStep = Math.Sign(segment.End.X - segment.Start.X);

                var y = segment.Start.Y;
                var yStep = Math.Sign(segment.End.Y - segment.Start.Y);

                while (true)
                {
                    if (ignoreDiagonals)
                    if (xStep != 0 && yStep != 0) { break; }

                    plane[x, y] += 1;

                    if (xStep != 0)
                    {
                        x += xStep;

                        if (x == segment.End.X + xStep) { break; }
                    }

                    if (yStep != 0)
                    {
                        y += yStep;

                        if (y == segment.End.Y + yStep) { break; }
                    }
                }
            }

            var count = 0;
            for (var y = 0; y <= yMax; y++)
            for (var x = 0; x <= xMax; x++)
            if (2 <= plane[x, y]) { count += 1; }

            Console.WriteLine(count);
        }
    }
}