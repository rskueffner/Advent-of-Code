namespace Aoc
{
    public static class PartSolver
    {
        public static void Solve<P, R>()
        where P : Part<R>
        {
            var type = typeof(P);

            using var stream = type.Assembly.GetManifestResourceStream(type, "Input.txt")
                ?? throw new ArgumentException();

            using var reader = new StreamReader(stream);

            var input = reader.ReadToEnd();

            var signature = new Type[] { typeof(String) };
            var constructor = type.GetConstructor(signature)
                ?? throw new ArgumentException();

            var parameters = new Object[] { input };
            var instance = constructor.Invoke(parameters) as P
                ?? throw new ArgumentException();

            var solution = instance.Solve();

            Console.WriteLine($"--- {type.FullName} ---");
            Console.WriteLine();
            Console.WriteLine(solution);
        }
    }
}
