using System;

namespace Aoc2021.Day02
{
    public class Part2 : Part1
    {
        public Part2(String input) : base(input)
        { }

        public override void Solve()
        {
            var horizontalPosition = 0;
            var depth = 0;
            var aim = 0;

            foreach (var command in this.commands)
            switch (command.Direction)
            {
                case Direction.Forward:
                    horizontalPosition += command.Units;
                    depth += aim * command.Units;
                    break;

                case Direction.Down:
                    aim += command.Units;
                    break;

                case Direction.Up:
                    aim -= command.Units;
                    break;

                default:
                    throw new NotSupportedException();
            }

            Console.WriteLine(horizontalPosition * depth);
        }
    }
}