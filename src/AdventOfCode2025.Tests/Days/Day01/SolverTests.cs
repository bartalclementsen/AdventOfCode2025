namespace AdventOfCode2025.Client.Days.Day01;

public class SolverTests
{
    public Solver GetUnit()
    {
        return new();
    }

    [Fact]
    public void Part1_Test_1()
    {
        // Arrange
        IEnumerable<string> input = """
            L68
            L30
            R48
            L5
            R60
            L55
            L1
            L99
            R14
            L82
            """.Split(Environment.NewLine);

        Solver unit = GetUnit();

        // Act
        string result = unit.Solve1(input);

        // Assert
        Assert.Equal("3", result);
    }

    [Fact]
    public void Part2_Test_1()
    {
        // Arrange
        IEnumerable<string> input = """
            L68
            L30
            R48
            L5
            R60
            L55
            L1
            L99
            R14
            L82
            """.Split(Environment.NewLine);

        Solver unit = GetUnit();

        // Act
        string result = unit.Solve2(input);

        // Assert
        Assert.Equal("6", result);
    }

    [Fact]
    public async Task Part1()
    {
        // Arrange
        Solver unit = GetUnit();
        string[] input = await unit.GetInputsAsync();

        // Act
        string result = unit.Solve1(input);

        // Assert
        Assert.Equal("1066", result);
    }

    [Fact]
    public async Task Part2()
    {
        // Arrange
        Solver unit = GetUnit();
        string[] input = await unit.GetInputsAsync();

        // Act
        string result = unit.Solve2(input);

        // Assert
        Assert.Equal("6223", result);
    }
}
