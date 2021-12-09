using System;
using System.Collections.Generic;

namespace Aoc2021.Day02
{
    public class Part1 : Aoc.Part<Int32>
    {
        public Part1(String input) : base(input)
        {
            this.commands = new List<Command>();

            var lines = input.Split(Environment.NewLine);
            foreach (var line in lines)
            {
                var parts = line.Split(' ');

                var command = new Command
                (
                    Direction: Enum.Parse<Direction>(parts[0], true),
                    Units: Int32.Parse(parts[1])
                );

                this.commands.Add(command);
            }
        }

        protected readonly IList<Command> commands;

        public override Int32 Solve()
        {
            var horizontalPosition = 0;
            var depth = 0;

            foreach (var command in this.commands)
            switch (command.Direction)
            {
                case Direction.Forward:
                    horizontalPosition += command.Units;
                    break;

                case Direction.Down:
                    depth += command.Units;
                    break;

                case Direction.Up:
                    depth -= command.Units;
                    break;

                default:
                    throw new NotSupportedException();
            }

            return horizontalPosition * depth;
        }
    }
}