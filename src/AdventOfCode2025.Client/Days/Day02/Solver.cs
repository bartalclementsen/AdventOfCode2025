
namespace AdventOfCode2025.Client.Days.Day02;

public class Solver : SolverBase
{

    public override string Solve1(IEnumerable<string> inputs)
    {
        //Parse
        List<Range> ranges = [];
        foreach (string input in inputs)
        {
            foreach (string range in input.Split(","))
            {
                string[] values = range.Split("-");
                ranges.Add(new Range(long.Parse(values[0]), long.Parse(values[1])));
            }
        }

        // Lookup Invalid Ids
        long sum = 0;
        foreach (Range range in ranges)
        {
            foreach (long id in range.GetInvalidId())
            {
                sum += id;
            }
        }

        return sum.ToString();
    }

    public override string Solve2(IEnumerable<string> inputs)
    {
        //Parse
        List<Range> ranges = [];
        foreach (string input in inputs)
        {
            foreach (string range in input.Split(","))
            {
                string[] values = range.Split("-");
                ranges.Add(new Range(long.Parse(values[0]), long.Parse(values[1])));
            }
        }

        // Lookup Invalid Ids
        long sum = 0;
        foreach (Range range in ranges)
        {
            foreach (long id in range.GetMoreInvalidId())
            {
                sum += id;
            }
        }

        return sum.ToString();
    }

    public record Range(long FirstId, long LastId)
    {
        public List<long> GetInvalidId()
        {
            List<long> invalidIds = [];
            for (long i = FirstId; i <= LastId; i++)
            {
                string id = i.ToString();
                if (id.Length % 2 != 0)
                {
                    continue;
                }

                string firstPart = id[..(id.Length / 2)];
                string secondPart = id[(id.Length / 2)..];
                if (firstPart == secondPart)
                {
                    invalidIds.Add(i);
                }
            }

            return invalidIds;
        }

        public List<long> GetMoreInvalidId()
        {
            List<long> invalidIds = [];
            for (long i = FirstId; i <= LastId; i++)
            {
                string id = i.ToString();
                for (int j = 1; j < (id.Length / 2) + 1; j++)
                {
                    // Build a substring to check
                    string toCheck = id[..j];
                    int length = toCheck.Length;
                    bool foundCounter = false;
                    // Check if any substring matches the ToCheck variables
                    for (int k = j; k < id.Length; k += length)
                    {
                        string checkAgainst = id.Substring(k, Math.Min(id.Length - k, length));
                        if (toCheck != checkAgainst)
                        {
                            foundCounter = true;
                            break;
                        }
                    }

                    if (!foundCounter)
                    {
                        invalidIds.Add(i);
                        break;
                    }
                }
            }

            return invalidIds;
        }
    }
}
