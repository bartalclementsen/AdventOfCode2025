namespace AdventOfCode2025.Client.Days.Day05;

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
            3-5
            10-14
            16-20
            12-18

            1
            5
            8
            11
            17
            32
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
            3-5
            10-14
            16-20
            12-18
            """.Split(Environment.NewLine);

        Solver unit = GetUnit();

        // Act
        string result = unit.Solve2(input);

        // Assert
        Assert.Equal("14", result);
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
        Assert.Equal("874", result);
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
        Assert.Equal("348548952146313", result);
    }
}
