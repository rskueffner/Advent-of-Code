using System;
using System.IO;

namespace Cli
{
    public class Program
    {
        public static void Main()
        {
            Invoke<Aoc2021.Day06.Part2>();
        }

        private static void Invoke<T>()
        where T : Aoc.Part
        {
            using (var stream = typeof(T).Assembly.GetManifestResourceStream(typeof(T), "Input.txt"))
            using (var reader = new StreamReader(stream))
            {
                var input = reader.ReadToEnd();

                var signature = new Type[] { typeof(String) };
                var constructor = typeof(T).GetConstructor(signature);

                var parameters = new Object[] { input };
                var part = constructor.Invoke(parameters) as T;

                part.Solve();
            }
        }
    }
}