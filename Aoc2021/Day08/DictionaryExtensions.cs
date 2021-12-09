using System;
using System.Collections.Generic;
using System.Text;

namespace Aoc2021.Day08
{
    public static class DictionaryExtensions
    {
        public static IEnumerable<T> Apply<T>(this Dictionary<T, T> map, IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                yield return map[value];
            }
        }

        public static String Apply(this Dictionary<Char, Char> cipher, String text)
        {
            var result = new StringBuilder();

            foreach (var letter in text)
            {
                result.Append(cipher[letter]);
            }

            return result.ToString();
        }
    }
}
