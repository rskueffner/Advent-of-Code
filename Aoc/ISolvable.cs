using System;

namespace Aoc
{
    public interface ISolvable<T>
    {
        public T Solve();
    }
}
