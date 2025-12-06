namespace AdventOfCode2025.Client.Days.Day06;

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
            123 328  51 64 
             45 64  387 23 
              6 98  215 314
            *   +   *   + 
            """.Split(Environment.NewLine);

        Solver unit = GetUnit();

        // Act
        string result = unit.Solve1(input);

        // Assert
        Assert.Equal("4277556", result);
    }

    [Fact]
    public void Part2_Test_1()
    {
        // Arrange
        IEnumerable<string> input = """
            123 328  51 64 
             45 64  387 23 
              6 98  215 314
            *   +   *   + 
            """.Split(Environment.NewLine);

        Solver unit = GetUnit();

        // Act
        string result = unit.Solve2(input);

        // Assert
        Assert.Equal("3263827", result);
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
        Assert.Equal("5977759036837", result);
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
        Assert.Equal("9630000828442", result);
    }
}
