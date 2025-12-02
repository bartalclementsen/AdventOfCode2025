namespace AdventOfCode2025.Client.Days.Day02;

public class SolverTests
{
    public Solver GetUnit()
    {
        return new();
    }

    [Theory]
    [InlineData("11-22", "2")]
    [InlineData("95-115", "1")]
    [InlineData("998-1012", "1")]
    [InlineData("1188511880-1188511890", "1")]
    [InlineData("222220-222224", "1")]
    [InlineData("1698522-1698528", "0")]
    [InlineData("446443-446449", "1")]
    [InlineData("38593856-38593862", "1")]
    public void Part1_Test_1(string ids, string invalidIds)
    {
        // Arrange
        IEnumerable<string> input = ids.Split(Environment.NewLine);

        Solver unit = GetUnit();

        // Act
        var split = ids.Split("-");
        var range = new Solver.Range(long.Parse(split[0]), long.Parse(split[1]));

        // Assert
        Assert.Equal(invalidIds, range.GetInvalidId().Count.ToString());
    }

    [Fact]
    public void Part1_Test_2()
    {
        // Arrange
        IEnumerable<string> input = "11-22, 95-115, 998-1012, 1188511880-1188511890, 222220-222224, 1698522-1698528, 446443-446449, 38593856-38593862".Split(Environment.NewLine);

        Solver unit = GetUnit();

        // Act
        string result = unit.Solve1(input);

        // Assert
        Assert.Equal("1227775554", result);
    }

    [Theory]
    [InlineData("11-22", "2")]
    [InlineData("95-115", "2")]
    [InlineData("998-1012", "2")]
    [InlineData("1188511880-1188511890", "1")]
    [InlineData("222220-222224", "1")]
    [InlineData("1698522-1698528", "0")]
    [InlineData("446443-446449", "1")]
    [InlineData("38593856-38593862", "1")]
    [InlineData("565653-565659", "1")]
    [InlineData("824824821-824824827", "1")]
    [InlineData("2121212118-2121212124", "1")]
    public void Part2_Test_1(string ids, string invalidIds)
    {
        // Arrange
        IEnumerable<string> input = ids.Split(Environment.NewLine);

        // Act
        var split = ids.Split("-");
        var range = new Solver.Range(long.Parse(split[0]), long.Parse(split[1]));

        // Assert
        Assert.Equal(invalidIds, range.GetMoreInvalidId().Count.ToString());
    }

    [Fact]
    public void Part2_Test_2()
    {
        // Arrange
        IEnumerable<string> input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124".Split(Environment.NewLine);

        Solver unit = GetUnit();

        // Act
        string result = unit.Solve2(input);

        // Assert
        Assert.Equal("4174379265", result);
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
        Assert.Equal("21898734247", result);
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
        Assert.Equal("28915664389", result);
    }
}
