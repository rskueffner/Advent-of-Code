using System.Reflection;

namespace Aoc
{
    public abstract class Part : ISolvable
    {
        public Part(String input)
        { }

        public abstract void Solve();
    }
}