namespace AdventOfCode2025.Client.Days.Day03;

public class Solver : SolverBase
{
    public override string Solve1(IEnumerable<string> inputs)
    {
        List<BatteryBank> batteryBanks = [];
        foreach (string input in inputs)
        {
            BatteryBank batteryBank = new();
            batteryBanks.Add(batteryBank);

            for (int i = 0; i < input.Length; i++)
            {
                batteryBank.Batteries.Add(new Battery
                {
                    Position = i,
                    Joltage = int.Parse(input[i].ToString())
                });
            }
        }


        long maxTotalJolage = 0;
        foreach (BatteryBank batteryBank in batteryBanks)
        {
            int maxJoltage = 0;
            for (int i = 0; i < batteryBank.Batteries.Count - 1; i++)
            {
                Battery firstJoltage = batteryBank.Batteries[i];
                for (int j = i + 1; j < batteryBank.Batteries.Count; j++)
                {
                    Battery secondJoltage = batteryBank.Batteries[j];
                    var totalJoltage = int.Parse($"{firstJoltage}{secondJoltage}");
                    if (totalJoltage > maxJoltage)
                    {
                        maxJoltage = totalJoltage;
                    }
                }
            }
            maxTotalJolage += maxJoltage;
        }

        return maxTotalJolage.ToString();
    }

    public override string Solve2(IEnumerable<string> inputs)
    {
        long maxTotalJoltage = 0;

        foreach (string input in inputs)
        {
            string maxJoltage = FindMaxJoltage(input, 12);
            maxTotalJoltage += long.Parse(maxJoltage);
        }

        return maxTotalJoltage.ToString();
    }

    private string FindMaxJoltage(string digits, int count)
    {
        int n = digits.Length;
        List<char> result = [];
        int startIndex = 0;

        for (int i = 0; i < count; i++)
        {
            int remainingToSelect = count - i - 1;
            int lastPossibleIndex = n - remainingToSelect - 1;

            char maxDigit = '0';
            int maxDigitIndex = startIndex;

            for (int j = startIndex; j <= lastPossibleIndex; j++)
            {
                if (digits[j] > maxDigit)
                {
                    maxDigit = digits[j];
                    maxDigitIndex = j;
                }
            }

            result.Add(maxDigit);
            startIndex = maxDigitIndex + 1;
        }

        return new string(result.ToArray());
    }

    public class BatteryBank
    {
        public List<Battery> Batteries { get; set; } = [];

        public override string ToString()
        {
            return string.Join("", Batteries);
        }
    }

    public class Battery
    {
        public int Position { get; set; }

        public int Joltage { get; set; }

        public override string ToString()
        {
            return Joltage.ToString();
        }
    }
}
