namespace AdventOfCode2025.Client;

public abstract class SolverBase
{
    public string GetDay()
    {
        return GetType().ToString()
            .Split(".")
            .Skip(3)
            .First();
    }

    public Task<string[]> GetInputsAsync(CancellationToken cancellationToken = default)
    {
        string path = GetType().ToString()
            .Replace("AdventOfCode2025.Client.", "")
            .Replace(".", "\\")
            .Replace("Solver", "Input.txt");

        return File.ReadAllLinesAsync(path, cancellationToken);
    }

    public virtual string Solve1(IEnumerable<string> inputs)
    {
        return "NotImplemented";
    }

    public virtual string Solve2(IEnumerable<string> inputs)
    {
        return "NotImplemented";
    }
}
