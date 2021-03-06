using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2021.Day04
{
    public class Part1 : Aoc.Part<Int32>
    {
        public Part1(String input) : base(input)
        {
            var lines = input.Split(Environment.NewLine);

            this.drawings = new List<Int32>();
            DeserializeDrawings(lines[0]);

            this.boards = new List<Board>();
            DeserializeBoards(lines[2..]);
        }

        protected IList<Board> boards;

        protected IList<Int32> drawings;

        public override Int32 Solve()
        {
            foreach (var drawing in this.drawings)
            foreach (var board in this.boards)
            {
                board.Record(drawing);

                if (board.IsWinner()) { return board.Score(drawing); }
            }

            throw new NotImplementedException();
        }

        private void DeserializeBoards(IList<String> input)
        {
            var numbers = new List<Int32>();
            foreach (var line in input)
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

        private void DeserializeDrawings(String input)
        {
            foreach (var drawing in input.Split(','))
            {
                var number = Convert.ToInt32(drawing);

                this.drawings.Add(number);
            }
        }
    }
}