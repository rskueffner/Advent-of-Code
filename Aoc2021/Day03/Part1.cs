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
            this.numbers = new List<Int32>();

            var lines = this.input.Split(Environment.NewLine);
            foreach (var line in lines)
            {
                this.bits = Math.Max(bits, line.Length - 1);

                var number = Convert.ToInt32(line, 2);
                
                numbers.Add(number);
            }
        }

        protected readonly Int32 bits;

        protected readonly IList<Int32> numbers;

        public static Int32 GetBit(Int32 index, Int32 number)
        {
            return (number >> index) & 1;
        }

        public static Int32 LeastCommonBit(Int32 index, IList<Int32> numbers)
        {
            if (numbers.Count() == 1)
            {
                var number = numbers.Single();
                return GetBit(index, number);
            }

            var ones = 0;
            foreach (var number in numbers)
            {
                ones += GetBit(index, number);
            }

            var zeroes = numbers.Count() - ones;
            
            if (zeroes <= ones) { return 0; }
            else { return 1; }
        }

        public static Int32 MostCommonBit(Int32 index, IList<Int32> numbers)
        {
            if (numbers.Count() == 1)
            {
                var number = numbers.Single();
                return GetBit(index, number);
            }

            var ones = 0;
            foreach (var number in numbers)
            {
                ones += GetBit(index, number);
            }

            var zeroes = numbers.Count() - ones;

            if (zeroes <= ones) { return 1; }
            else { return 0; }
        }

        public override void Solve()
        {
            var gamma = String.Empty;
            for (var i = this.bits; 0 <= i; i--)
            {
                gamma += MostCommonBit(i, this.numbers);
            }

            var epsilon = String.Empty;
            for (var i = this.bits; 0 <= i; i--)
            {
                epsilon += LeastCommonBit(i, this.numbers);
            }

            var gammaRate = Convert.ToInt32(gamma, 2);
            var epsilonRate = Convert.ToInt32(epsilon, 2);

            var powerConsumption = gammaRate * epsilonRate;

            Console.Write(powerConsumption);
        }
    }
}