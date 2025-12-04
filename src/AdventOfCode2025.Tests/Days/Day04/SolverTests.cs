namespace AdventOfCode2025.Client.Days.Day04;

public class SolverTests
{
    public Solver GetUnit()
    {
        return new();
    }

    [Fact]
    public void Part1_Test_0()
    {
        // Arrange
        IEnumerable<string> input = """
            ..@@.@@@@.
            @@@.@.@.@@
            @@@@@.@.@@
            @.@@@@..@.
            @@.@@@@.@@
            .@@@@@@@.@
            .@.@.@.@@@
            @.@@@.@@@@
            .@@@@@@@@.
            @.@.@@@.@.
            """.Split(Environment.NewLine);

        IEnumerable<string> result = """
            ..xx.xx@x.
            x@@.@.@.@@
            @@@@@.x.@@
            @.@@@@..@.
            x@.@@@@.@x
            .@@@@@@@.@
            .@.@.@.@@@
            x.@@@.@@@@
            .@@@@@@@@.
            x.x.@@@.x.
            """.Split(Environment.NewLine);

        // Act
        Solver.Grid g = Solver.Grid.FromInputs(input);

        string expected = string.Join(Environment.NewLine, result);
        string actual = g.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Part1_Test_1()
    {
        // Arrange
        IEnumerable<string> input = """
            ..@@.@@@@.
            @@@.@.@.@@
            @@@@@.@.@@
            @.@@@@..@.
            @@.@@@@.@@
            .@@@@@@@.@
            .@.@.@.@@@
            @.@@@.@@@@
            .@@@@@@@@.
            @.@.@@@.@.
            """.Split(Environment.NewLine);

        Solver unit = GetUnit();

        // Act
        string result = unit.Solve1(input);

        // Assert
        Assert.Equal("13", result);
    }

    [Fact]
    public void Part2_Test_0()
    {
        // Arrange
        IEnumerable<string> input = """
            ..@@.@@@@.
            @@@.@.@.@@
            @@@@@.@.@@
            @.@@@@..@.
            @@.@@@@.@@
            .@@@@@@@.@
            .@.@.@.@@@
            @.@@@.@@@@
            .@@@@@@@@.
            @.@.@@@.@.
            """.Split(Environment.NewLine);

        Solver.Grid g = Solver.Grid.FromInputs(input);

        // Act
        int removed = g.RemoveAccessableRollsOfPaper();

        string expected = """
            .......x..
            .@@.x.x.@x
            x@@@@...@@
            x.@@@@..x.
            .@.@@@@.x.
            .x@@@@@@.x
            .x.@.@.@@@
            ..@@@.@@@@
            .x@@@@@@@.
            ....@@@...
            """;
        string actual = g.ToString();
        Assert.Equal(expected, actual);
        Assert.Equal(13, removed);

        removed = g.RemoveAccessableRollsOfPaper();
        expected = """
            ..........
            .x@.....x.
            .@@@@...xx
            ..@@@@....
            .x.@@@@...
            ..@@@@@@..
            ...@.@.@@x
            ..@@@.@@@@
            ..x@@@@@@.
            ....@@@...
            """;
        actual = g.ToString();
        Assert.Equal(expected, actual);
        Assert.Equal(12, removed);

        removed = g.RemoveAccessableRollsOfPaper();
        expected = """
            ..........
            ..x.......
            .x@@@.....
            ..@@@@....
            ...@@@@...
            ..x@@@@@..
            ...@.@.@@.
            ..x@@.@@@x
            ...@@@@@@.
            ....@@@...
            """;

        actual = g.ToString();
        Assert.Equal(expected, actual);
        Assert.Equal(7, removed);

        //while (g.GetAccessableRollsOfPaperCount() > 0)
        //{
        //    removed = 
        //}


    }

    [Fact]
    public void Part2_Test_1()
    {
        // Arrange
        IEnumerable<string> input = """
            ..@@.@@@@.
            @@@.@.@.@@
            @@@@@.@.@@
            @.@@@@..@.
            @@.@@@@.@@
            .@@@@@@@.@
            .@.@.@.@@@
            @.@@@.@@@@
            .@@@@@@@@.
            @.@.@@@.@.
            """.Split(Environment.NewLine);

        Solver unit = GetUnit();

        // Act
        string result = unit.Solve2(input);

        // Assert
        Assert.Equal("43", result);
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
        Assert.Equal("1527", result);
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
        Assert.Equal("8690", result);
    }
}
