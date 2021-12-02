namespace Aoc
{
    public abstract class Part
    {
        public Part(String input)
        {
            this.input = input;
        }

        protected readonly String input;

        public abstract void Solve();
    }
}