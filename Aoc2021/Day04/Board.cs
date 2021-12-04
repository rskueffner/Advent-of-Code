using System;

namespace Aoc2021.Day04
{
    public struct Board
    {
        public Board(Int32[] numbers)
        {
            if (numbers.Length != 25) { throw new ArgumentException(); }

            this.matches = new Boolean[25];
            this.numbers = numbers;
        }

        private readonly Boolean[] matches;

        private readonly Int32[] numbers;

        public Boolean IsWinner()
        {
            for (var r = 0; r < 5; r++)
            {
                var row = true;
                var column = true;

                for (var c = 0; c < 5; c++)
                {
                    row    &= this.matches[5 * r + c];
                    column &= this.matches[5 * c + r];
                }

                if (row | column) { return true; }
            }

            return false;
        }

        public Boolean Record(Int32 number)
        {
            var match = false;

            var index = -1;
            while (true)
            {
                index = Array.IndexOf(this.numbers, number, index + 1);

                if (index == -1) { break; }

                this.matches[index] = true;

                match = true;
            }

            return match;
        }

        public Int32 Score(Int32 drawing)
        {
            var sum = 0;

            for (var i = 0; i < 25; i++)
            if (!this.matches[i]) { sum += this.numbers[i]; }

            return sum * drawing;
        }
    }
}
