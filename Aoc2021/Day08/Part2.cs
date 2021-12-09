using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2021.Day08
{
    public class Part2 : Part1
    {
        public Part2(String input) : base(input)
        {
            this.map = new Dictionary<String, Int32>()
            {
                { "abcefg" , 0 },
                { "cf"     , 1 },
                { "acdeg"  , 2 },
                { "acdfg"  , 3 },
                { "bcdf"   , 4 },
                { "abdfg"  , 5 },
                { "abdefg" , 6 },
                { "acf"    , 7 },
                { "abcdefg", 8 },
                { "abcdfg" , 9 },
            };
        }

        protected readonly IDictionary<String, Int32> map;

        public static IEnumerable<String> Permutations(String value)
        {
            (var start, var end) = (0, value.Length - 1);

            var permutations = Permutations(value.ToArray(), start, end);
            foreach (var permutation in permutations)
            {
                yield return new String(permutation);
            }
        }

        public static IEnumerable<Char[]> Permutations(Char[] value, Int32 start, Int32 end)
        {
            if (start == end)
            {
                var result = new Char[value.Length];
                Array.Copy(value, result, value.Length);

                yield return result;
            }

            for (var i = start; i <= end; i++)
            {
                (value[start], value[i]) = (value[i], value[start]);

                foreach (var permutation in Permutations(value, start + 1, end))
                {
                    yield return permutation;
                }
                
                (value[start], value[i]) = (value[i], value[start]);
            }
        }

        public static Dictionary<Char, Char> GetCipher(String source, String target)
        {
            var dictionary = new Dictionary<Char, Char>();

            var length = Math.Min(source.Length, target.Length);
            for (var i = 0; i < length; i++)
            {
                dictionary.Add(source[i], target[i]);
            }

            return dictionary;
        }

        public override Int32 Solve()
        {
            var total = 0;

            foreach (var entry in this.entries)
            foreach (var permutation in Permutations("abcdefg"))
            {
                var cipher = GetCipher(permutation, "abcdefg");

                var displays = entry
                    .Select(e => cipher.Apply(e))
                    .Select(s => new String(s.OrderBy(c => c).ToArray()))
                    .ToArray();

                var signalPatterns = new HashSet<String>(displays[..10]);
                if (!signalPatterns.IsSubsetOf(this.map.Keys)) { continue; }

                var outputValues = displays[^4..];
                for (var i = 1; i <= outputValues.Length; i++)
                {
                    var coefficient = (Int32) Math.Pow(10, i - 1);
                        
                    total += coefficient * this.map[outputValues[^i]]; 
                }

                break;
            }

            return total;
        }
    }
}