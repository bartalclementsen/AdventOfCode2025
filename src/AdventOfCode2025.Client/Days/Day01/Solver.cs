
namespace AdventOfCode2025.Client.Days.Day01;

public class Solver : SolverBase
{
    public override string Solve1(IEnumerable<string> inputs)
    {
        int timesZeroHit = 0;
        int currentNumber = 50;
        foreach (string input in inputs)
        {
            string direction = input[..1];
            int distance = int.Parse(input[1..]);

            if (direction == "L")
            {
                currentNumber -= distance;
            }
            else if (direction == "R")
            {
                currentNumber += distance;
            }

            currentNumber = Mod(currentNumber, 100);

            if (currentNumber == 0)
            {
                timesZeroHit++;
            }
        }

        return timesZeroHit.ToString();
    }

    public override string Solve2(IEnumerable<string> inputs)
    {
        int timesZeroHit = 0;
        int currentNumber = 50;
        foreach (string input in inputs)
        {
            string direction = input[..1];
            int distance = int.Parse(input[1..]);

            for (int i = 0; i < distance; i++)
            {
                if (direction == "R")
                {
                    currentNumber++;
                }
                else
                {
                    currentNumber--;
                }
                currentNumber = Mod(currentNumber, 100);
                if (currentNumber == 0)
                {
                    timesZeroHit++;
                }
            }
        }

        return timesZeroHit.ToString();
    }

    private int Mod(int x, int m)
    {
        int r = x % m;
        return r < 0 ? r + m : r;
    }
}
