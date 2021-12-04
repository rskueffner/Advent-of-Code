using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2021.Day04
{
    public class Part1 : Aoc.Part
    {
        public Part1(String input) : base(input)
        {
            var lines = this.input.Split(Environment.NewLine);

            this.drawings = new List<Int32>();
            DeserializeDrawings(lines[0]);

            this.boards = new List<Board>();
            DeserializeBoards(lines[2..]);
        }

        protected IList<Board> boards;

        protected IList<Int32> drawings;

        public override void Solve()
        {
            foreach (var drawing in this.drawings)
            foreach (var board in this.boards)
            {
                board.Record(drawing);

                if (board.IsWinner())
                {
                    Console.WriteLine(board.Score(drawing));

                    return;
                }
            }
        }

        private void DeserializeBoards(IList<String> lines)
        {
            var numbers = new List<Int32>();
            foreach (var line in lines)
            {
                var row = line
                    .Split(' ')
                    .Where(s => !String.IsNullOrWhiteSpace(s))
                    .Select(s => Convert.ToInt32(s));

                numbers.AddRange(row);
            }

            for (var i = 0; i < numbers.Count; i += 25)
            {
                var range = numbers
                    .Skip(i)
                    .Take(25)
                    .ToArray();

                var board = new Board(range);

                this.boards.Add(board);
            }
        }

        private void DeserializeDrawings(String line)
        {
            foreach (var drawing in line.Split(','))
            {
                var number = Convert.ToInt32(drawing);

                this.drawings.Add(number);
            }
        }
    }
}