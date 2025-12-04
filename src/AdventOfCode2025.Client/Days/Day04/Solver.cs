
using System.Text;

namespace AdventOfCode2025.Client.Days.Day04;

public class Solver : SolverBase
{
    public override string Solve1(IEnumerable<string> inputs)
    {
        Grid grid = Grid.FromInputs(inputs);


        return grid.GetAccessableRollsOfPaperCount().ToString();
    }

    public override string Solve2(IEnumerable<string> inputs)
    {
        Grid grid = Grid.FromInputs(inputs);

        int removed = 0;
        while (grid.GetAccessableRollsOfPaperCount() > 0)
        {
            removed += grid.RemoveAccessableRollsOfPaper();
        }

        return removed.ToString();
    }

    public class Grid(int width, int height)
    {
        private readonly IElement[,] _grid = new IElement[width, height];

        public void AddElement(char c, int x, int y)
        {
            _grid[x, y] = c switch
            {
                '@' => new RollOfPaper(),
                '.' => new Empty(),
                _ => throw new ArgumentException($"Invalid character '{c}' for grid element."),
            };
        }

        public IElement GetElement(int x, int y)
        {
            return _grid[x, y];
        }

        public int GetAccessableRollsOfPaperCount()
        {
            int count = 0;
            for (int y = 0; y < _grid.GetLength(1); y++)
            {
                for (int x = 0; x < _grid.GetLength(0); x++)
                {
                    if (_grid[x, y] is RollOfPaper rollOfPaper && rollOfPaper.CanAccess)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            for (int y = 0; y < _grid.GetLength(1); y++)
            {
                for (int x = 0; x < _grid.GetLength(0); x++)
                {
                    sb.Append(_grid[x, y]);
                }

                if (y < _grid.GetLength(1) - 1)
                {
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }

        public static Grid FromInputs(IEnumerable<string> inputs)
        {
            int width = inputs.ElementAt(0).Length;
            int height = inputs.Count();
            Grid grid = new(width, height);

            for (int y = 0; y < inputs.Count(); y++)
            {
                string input = inputs.ElementAt(y);
                for (int x = 0; x < input.Length; x++)
                {
                    grid.AddElement(input[x], x, y);
                }
            }

            // Populate neighbors
            for (int y = 0; y < inputs.Count(); y++)
            {
                string input = inputs.ElementAt(y);
                for (int x = 0; x < input.Length; x++)
                {
                    IElement element = grid.GetElement(x, y);
                    element.North = y > 0 ? grid.GetElement(x, y - 1) : null;
                    element.NorthEast = (x < width - 1 && y > 0) ? grid.GetElement(x + 1, y - 1) : null;
                    element.East = x < width - 1 ? grid.GetElement(x + 1, y) : null;
                    element.SouthEast = (x < width - 1 && y < height - 1) ? grid.GetElement(x + 1, y + 1) : null;
                    element.South = y < height - 1 ? grid.GetElement(x, y + 1) : null;
                    element.SouthWest = (x > 0 && y < height - 1) ? grid.GetElement(x - 1, y + 1) : null;
                    element.West = x > 0 ? grid.GetElement(x - 1, y) : null;
                    element.NorthWest = (x > 0 && y > 0) ? grid.GetElement(x - 1, y - 1) : null;
                }
            }

            return grid;
        }

        public int RemoveAccessableRollsOfPaper()
        {
            List<RollOfPaper> removed = [];
            for (int y = 0; y < _grid.GetLength(1); y++)
            {
                for (int x = 0; x < _grid.GetLength(0); x++)
                {
                    if (_grid[x, y] is RollOfPaper rollOfPaper && rollOfPaper.CanAccess)
                    {
                        removed.Add(rollOfPaper);
                        _grid[x, y] = new Empty();
                    }
                }
            }

            // Update neighbors to remove references to this roll of paper
            foreach (RollOfPaper rollOfPaper in removed)
            {
                rollOfPaper.North?.South = rollOfPaper.North?.South == rollOfPaper ? null : rollOfPaper.North?.South;
                rollOfPaper.South?.North = rollOfPaper.South?.North == rollOfPaper ? null : rollOfPaper.South?.North;
                rollOfPaper.East?.West = rollOfPaper.East?.West == rollOfPaper ? null : rollOfPaper.East?.West;
                rollOfPaper.West?.East = rollOfPaper.West?.East == rollOfPaper ? null : rollOfPaper.West?.East;
                rollOfPaper.NorthEast?.SouthWest = rollOfPaper.NorthEast?.SouthWest == rollOfPaper ? null : rollOfPaper.NorthEast?.SouthWest;
                rollOfPaper.NorthWest?.SouthEast = rollOfPaper.NorthWest?.SouthEast == rollOfPaper ? null : rollOfPaper.NorthWest?.SouthEast;
                rollOfPaper.SouthEast?.NorthWest = rollOfPaper.SouthEast?.NorthWest == rollOfPaper ? null : rollOfPaper.SouthEast?.NorthWest;
                rollOfPaper.SouthWest?.NorthEast = rollOfPaper.SouthWest?.NorthEast == rollOfPaper ? null : rollOfPaper.SouthWest?.NorthEast;
            }

            return removed.Count;
        }
    }

    public interface IElement
    {
        public IElement? North { get; set; }
        public IElement? NorthEast { get; set; }
        public IElement? East { get; set; }
        public IElement? SouthEast { get; set; }
        public IElement? South { get; set; }
        public IElement? SouthWest { get; set; }
        public IElement? West { get; set; }
        public IElement? NorthWest { get; set; }
    }

    public abstract class Element : IElement
    {
        public IElement? North { get; set; }
        public IElement? NorthEast { get; set; }
        public IElement? East { get; set; }
        public IElement? SouthEast { get; set; }
        public IElement? South { get; set; }
        public IElement? SouthWest { get; set; }
        public IElement? West { get; set; }
        public IElement? NorthWest { get; set; }

        protected List<IElement?> _neighbors =>
        [
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West,
            NorthWest,
        ];

        public override string ToString()
        {
            return " ";
        }
    }

    public class RollOfPaper : Element
    {
        public bool CanAccess => _neighbors.Count(o => o is RollOfPaper) < 4;

        public override string ToString()
        {
            return CanAccess ? "x" : "@";
        }
    }

    public class Empty : Element
    {
        public override string ToString()
        {
            return ".";
        }
    }
}
