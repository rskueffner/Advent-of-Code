using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aoc2021.Day03
{
    public class Part1 : Aoc.Part
    {
        public Part1(String input) : base(input)
        {
            this.numbers = new List<Int32[]>();

            var lines = this.input.Split(Environment.NewLine);
            foreach (var line in lines)
            {
                var number = new Int32[line.Length];
                for (var i = 0; i < line.Length; i++)
                {
                    number[i] = Int32.Parse(line[i].ToString());
                }

                numbers.Add(number);
            }
        }

        protected readonly IList<Int32[]> numbers;

        public static Int32 MostCommonBit(Int32 index, IList<Int32[]> numbers)
        {
            if (numbers.Count() == 1) { return numbers.Single()[index]; }

            var ones = numbers.Where(n => n[index] == 1).Count();
            var zeroes = numbers.Count() - ones;

            if (zeroes <= ones) { return 1; }
            else { return 0; }
        }

        public static Int32 LeastCommonBit(Int32 index, IList<Int32[]> numbers)
        {
            if (numbers.Count() == 1) { return numbers.Single()[index]; }

            var zeroes = numbers.Where(n => n[index] == 0).Count();
            var ones = numbers.Count() - zeroes;

            if (zeroes <= ones) { return 0; }
            else { return 1; }
        }

        public static Int32 BinaryToDecimal(Int32[] binary)
        {
            var value = 0;

            for (var i = 0; i < binary.Length; i++)
            if (binary[i] == 1) { value += (Int32) Math.Pow(2, binary.Length - i - 1); }

            return value;
        }

        public override void Solve()
        {
            var length = this.numbers.First().Count();

            var gamma = new Int32[length];
            for (var i = 0; i < gamma.Length; i++)
            {
                gamma[i] = MostCommonBit(i, numbers);
            }

            var epsilon = new Int32[length];
            for (var i = 0; i < epsilon.Length; i++)
            {
                epsilon[i] = LeastCommonBit(i, numbers);
            }

            var gammeRate = BinaryToDecimal(gamma);
            var epsilonRate = BinaryToDecimal(epsilon);

            var powerConsumption = gammeRate * epsilonRate;

            Console.WriteLine(powerConsumption);
        }
    }
}