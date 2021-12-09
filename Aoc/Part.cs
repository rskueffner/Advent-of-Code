using System.Reflection;

namespace Aoc
{
    public abstract class Part<T> : ISolvable<T>
    {
        public Part(String input) { }

        public abstract T Solve();
    }
}