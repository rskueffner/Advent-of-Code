﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2021.Day04
{
    public class Part2 : Part1
    {
        public Part2(String input) : base(input)
        { }

        public override void Solve()
        {
            var winners = new Dictionary<Board, Int32>();

            for (var turn = 0; turn < this.drawings.Count; turn++)
            foreach (var board in this.boards)
            {
                if (winners.Keys.Contains(board))
                {
                    continue;
                }

                board.Record(this.drawings[turn]);

                if (board.IsWinner())
                {
                    winners[board] = turn;
                }
            }

            var maxTurn = winners.Values.Max();

            var loser = winners
                .Where(w => w.Value == maxTurn)
                .Select(w => w.Key)
                .Single();

            Console.WriteLine(loser.Score(this.drawings[maxTurn]));
        }
    }
}