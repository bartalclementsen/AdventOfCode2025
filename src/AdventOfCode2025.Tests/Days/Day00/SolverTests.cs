namespace AdventOfCode2025.Client.Days.Day00;

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
        IEnumerable<string> input = "".Split(Environment.NewLine);

        Solver unit = GetUnit();

        // Act
        string result = unit.Solve1(input);

        // Assert
        Assert.Equal("NotImplemented", result);
    }

    [Fact]
    public void Part2_Test_1()
    {
        // Arrange
        IEnumerable<string> input = "".Split(Environment.NewLine);

        Solver unit = GetUnit();

        // Act
        string result = unit.Solve2(input);

        // Assert
        Assert.Equal("NotImplemented", result);
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
        Assert.Equal("NotImplemented", result);
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
        Assert.Equal("NotImplemented", result);
    }
}
