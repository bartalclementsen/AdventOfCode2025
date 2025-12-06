namespace AdventOfCode2025.Client.Days.Day06;

public class Solver : SolverBase
{
    public override string Solve1(IEnumerable<string> inputs)
    {

        List<Problem> problems = [];
        foreach (string input in inputs)
        {
            string[] elements = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < elements.Length; i++)
            {
                string element = elements[i];
                Problem problem = new();
                if (problems.Count <= i)
                {
                    problems.Add(problem);
                }
                else
                {
                    problem = problems[i];
                }


                if (long.TryParse(element, out long number))
                {
                    problem.AddNumber(number);
                }
                else
                {
                    problem.AddOperation(element switch
                    {
                        "+" => Operation.Add,
                        "*" => Operation.Multiply,
                        _ => throw new InvalidOperationException("Unknown operation")
                    });
                }


            }

        }

        return problems.Sum(o => o.Solve()).ToString();
    }

    public override string Solve2(IEnumerable<string> inputs)
    {
        List<Problem> problems = [];
        int height = inputs.Count();
        int width = inputs.First().Length;
        Problem problem = new();
        problems.Add(problem);

        for (int i = width - 1; i >= 0; i--)
        {
            bool isEmptyLine = true;
            string currentNumber = "";
            for (int j = 0; j < height; j++)
            {
                if (j >= inputs.Count())
                {
                    continue;
                }

                string input = inputs.ElementAt(j);
                if (i >= input.Length)
                {
                    continue;
                }

                char element = input[i];
                if (element == ' ')
                {
                    // skip
                    continue;
                }
                else if (char.IsDigit(element))
                {
                    isEmptyLine = false;
                    currentNumber += element.ToString();
                }
                else
                {
                    isEmptyLine = false;
                    problem.AddOperation(element switch
                    {
                        '+' => Operation.Add,
                        '*' => Operation.Multiply,
                        _ => throw new InvalidOperationException("Unknown operation")
                    });
                }
            }

            if (!isEmptyLine)
            {
                problem.AddNumber(long.Parse(currentNumber));
            }
            else
            {
                problem = new Problem();
                problems.Add(problem);
            }
        }

        return problems.Sum(o => o.Solve()).ToString();
    }


    public class Problem
    {
        private readonly List<long> _number = [];

        private Operation _operation;

        public void AddNumber(long number)
        {
            _number.Add(number);
        }

        public void AddOperation(Operation operation)
        {
            _operation = operation;
        }

        public long Solve()
        {
            return _operation switch
            {
                Operation.Add => _number.Sum(),
                Operation.Multiply => _number.Aggregate(1L, (a, b) => a * b),
                _ => throw new InvalidOperationException("Unknown operation")
            };
        }
    }

    public enum Operation
    {
        Add,
        Multiply
    }
}
