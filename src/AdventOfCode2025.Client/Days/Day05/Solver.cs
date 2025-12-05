namespace AdventOfCode2025.Client.Days.Day05;

public class Solver : SolverBase
{
    public override string Solve1(IEnumerable<string> inputs)
    {
        List<FreshIngredientIdRange> ranges = [];
        List<AvailableIngredientId> availableIngredients = [];

        bool isRange = true;
        foreach (string input in inputs)
        {
            if (input.Length == 0)
            {
                isRange = false;
                continue;
            }

            if (isRange)
            {
                ranges.Add(new FreshIngredientIdRange
                {
                    IdFrom = long.Parse(input.Split('-')[0]),
                    IdTo = long.Parse(input.Split('-')[1])
                });
            }
            else
            {
                availableIngredients.Add(new AvailableIngredientId
                {
                    Id = long.Parse(input)
                });
            }
        }

        long freshCount = 0;
        foreach (var availableIngredient in availableIngredients)
        {
            if (ranges.Any(r => r.Contains(availableIngredient.Id)))
            {
                freshCount++;
            }
        }


        return freshCount.ToString();
    }

    public override string Solve2(IEnumerable<string> inputs)
    {
        List<FreshIngredientIdRange> ranges = [];
        List<AvailableIngredientId> availableIngredients = [];

        bool isRange = true;
        foreach (string input in inputs)
        {
            if (input.Length == 0)
            {
                isRange = false;
                continue;
            }

            if (isRange)
            {
                ranges.Add(new FreshIngredientIdRange
                {
                    IdFrom = long.Parse(input.Split('-')[0]),
                    IdTo = long.Parse(input.Split('-')[1])
                });
            }
            else
            {
                availableIngredients.Add(new AvailableIngredientId
                {
                    Id = long.Parse(input)
                });
            }
        }

        var sortedRanges = ranges.OrderBy(o => o.IdFrom).ThenBy(o => o.IdTo).ToList();

        // Rebalance ranges
        for (int i = 0; i < sortedRanges.Count; i++)
        {
            var range = sortedRanges[i];
            for (int j = i + 1; j < sortedRanges.Count; j++)
            {
                var otherRange = sortedRanges[j];

                if (otherRange.IsInside(range))
                {
                    sortedRanges.RemoveAt(j);
                    j--;
                }
                else if (otherRange.IdFrom <= range.IdTo)
                {
                    otherRange.IdFrom = range.IdTo + 1;
                }

            }
        }

        return sortedRanges.Sum(r => r.Length).ToString();
    }

    public record AvailableIngredientId
    {
        public required long Id { get; init; }
    }

    public class FreshIngredientIdRange
    {
        public long IdFrom { get; set; }

        public long IdTo { get; set; }

        public long Length => IdTo - IdFrom + 1;

        public bool Contains(long id)
        {
            return id >= IdFrom && id <= IdTo;
        }

        public bool IsInside(FreshIngredientIdRange other)
        {
            return IdFrom >= other.IdFrom && IdTo <= other.IdTo;
        }
    }
}
