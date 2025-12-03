
using System.Diagnostics.Contracts;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

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

            for(int i = 0; i < input.Length; i++)
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
                var firstJoltage = batteryBank.Batteries[i];
                for(int j = i + 1; j < batteryBank.Batteries.Count; j++)
                {
                    var secondJoltage = batteryBank.Batteries[j];
                    var totalJoltage = int.Parse($"{firstJoltage}{secondJoltage}");
                    if(totalJoltage > maxJoltage)
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
            long maxJoltage = 0;
            for (int i = 0; i < batteryBank.Batteries.Count - 1; i++)
            {
                var firstJoltage = batteryBank.Batteries[i];
                for (int j = i + 1; j < batteryBank.Batteries.Count; j++)
                {
                    var secondJoltage = batteryBank.Batteries[j];
                    for (int k = j + 1; k < batteryBank.Batteries.Count; k++)
                    {
                        var thirdJoltage = batteryBank.Batteries[k];
                        for (int l = k + 1; l < batteryBank.Batteries.Count; l++)
                        {
                            var forthJoltage = batteryBank.Batteries[l];
                            for (int m = l + 1; m < batteryBank.Batteries.Count; m++)
                            {
                                var fifthJoltage = batteryBank.Batteries[m];
                                for (int n = m + 1; n < batteryBank.Batteries.Count; n++)
                                {
                                    var sixthJoltage = batteryBank.Batteries[n];
                                    for (int o = n + 1; o < batteryBank.Batteries.Count; o++)
                                    {
                                        var seventJoltage = batteryBank.Batteries[o];
                                        for (int p = o + 1; p < batteryBank.Batteries.Count; p++)
                                        {
                                            var eightJoltage = batteryBank.Batteries[p];
                                            for (int q = p + 1; q < batteryBank.Batteries.Count; q++)
                                            {
                                                var ninenthJoltage = batteryBank.Batteries[q];
                                                for (int r = q + 1; r < batteryBank.Batteries.Count; r++)
                                                {
                                                    var thenthJoltage = batteryBank.Batteries[r];
                                                    for (int s = r + 1; s < batteryBank.Batteries.Count; s++)
                                                    {
                                                        var eleventJoltage = batteryBank.Batteries[s];
                                                        for (int t = s + 1; t < batteryBank.Batteries.Count; t++)
                                                        {
                                                            var tvewlvethJoltage = batteryBank.Batteries[t];
                                                            var totalJoltage = long.Parse($"{firstJoltage}{secondJoltage}{thirdJoltage}{forthJoltage}{fifthJoltage}{sixthJoltage}{seventJoltage}{eightJoltage}{ninenthJoltage}{thenthJoltage}{eleventJoltage}{tvewlvethJoltage}");
                                                            if (totalJoltage > maxJoltage)
                                                            {
                                                                maxJoltage = totalJoltage;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            
            maxTotalJolage += maxJoltage;
        }

        return maxTotalJolage.ToString();
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
