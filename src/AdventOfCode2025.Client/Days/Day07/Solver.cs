
using System.Numerics;
using System.Text;

namespace AdventOfCode2025.Client.Days.Day07;

public class Solver : SolverBase
{

    public override string Solve1(IEnumerable<string> inputs)
    {
        TachyonManifolds tachyonManifolds = new(inputs);
        while (tachyonManifolds.CanStep())
        {
            tachyonManifolds.Step();
        }

        return tachyonManifolds.SplitCount.ToString();
    }

    public override string Solve2(IEnumerable<string> inputs)
    {
        TachyonManifolds tachyonManifolds = new(inputs, isQuantumTachyonManifold: true);
        while (tachyonManifolds.CanStep())
        {
            tachyonManifolds.Step();
        }

        return tachyonManifolds.TotalNumberOfBeams.ToString();
    }

    public class TachyonManifolds
    {
        private Node StartNode { get; set; } = new();
        private Node[,] CurrentState { get; set; }
        private readonly List<Node> NodesToMove = [];
        public int SplitCount { get; private set; } = 0;
        private int StepIndex { get; set; }
        private readonly bool _isQuantumTachyonManifold = false;

        public long TotalNumberOfBeams
        {
            get
            {
                long totalNumberOfBeams = 0;

                for (int x = 0; x < CurrentState.GetLength(1); x++)
                {
                    totalNumberOfBeams += CurrentState[Math.Min(CurrentState.GetLength(0) - 1, StepIndex), x].NumberOfBeams;
                }

                return totalNumberOfBeams;
            }
        }

        //public long TotalNumberOfBeams { get; private set; }

        public TachyonManifolds(IEnumerable<string> initalState, int stepIndex = 0, bool isQuantumTachyonManifold = false)
        {
            _isQuantumTachyonManifold = isQuantumTachyonManifold;
            StepIndex = stepIndex;

            // Parse
            CurrentState = new Node[initalState.Count(), initalState.ElementAt(0).Length];
            for (int y = 0; y < initalState.Count(); y++)
            {
                string line = initalState.ElementAt(y);

                for (int x = 0; x < line.Length; x++)
                {
                    Node node = new()
                    {
                        Position = new Vector2(x, y),
                        Type = line[x] switch
                        {
                            '.' => NodeType.Empty,
                            '|' => NodeType.Empty,
                            'S' => NodeType.Start,
                            '^' => NodeType.Splitter,
                            _ => throw new NotImplementedException(),
                        }
                    };

                    if (line[x] == '|')
                    {
                        node.NumberOfBeams = 1;
                    }

                    if (stepIndex == 0 && node.Type == NodeType.Start)
                    {
                        StartNode = node;
                        StartNode.NumberOfBeams = 1;
                        NodesToMove.Add(node);
                    }
                    else if (y == stepIndex && node.HasBeam)
                    {
                        NodesToMove.Add(node);
                    }

                    CurrentState[y, x] = node;
                }
            }

            // Assign neighbors
            for (int y = 0; y < CurrentState.GetLength(0); y++)
            {
                for (int x = 0; x < CurrentState.GetLength(1); x++)
                {
                    Node node = CurrentState[y, x];
                    node.North = y > 0 ? CurrentState[y - 1, x] : null;
                    node.NorthEast = (y > 0 && x < CurrentState.GetLength(1) - 1) ? CurrentState[y - 1, x + 1] : null;
                    node.East = x < CurrentState.GetLength(1) - 1 ? CurrentState[y, x + 1] : null;
                    node.SouthEast = (y < CurrentState.GetLength(0) - 1 && x < CurrentState.GetLength(1) - 1) ? CurrentState[y + 1, x + 1] : null;
                    node.South = y < CurrentState.GetLength(0) - 1 ? CurrentState[y + 1, x] : null;
                    node.SouthWest = (y < CurrentState.GetLength(0) - 1 && x > 0) ? CurrentState[y + 1, x - 1] : null;
                    node.West = x > 0 ? CurrentState[y, x - 1] : null;
                    node.NorthWest = (y > 0 && x > 0) ? CurrentState[y - 1, x - 1] : null;
                }
            }
        }

        public bool CanStep()
        {
            return NodesToMove.Count > 0;
        }

        public void Step()
        {
            List<Node> currentNodesToMove = NodesToMove.ToList();
            NodesToMove.Clear();

            foreach (Node node in currentNodesToMove)
            {
                if (node.South is { Type: NodeType.Empty })
                {
                    node.South.NumberOfBeams += node.NumberOfBeams;
                    if (NodesToMove.Contains(node.South) == false)
                    {
                        NodesToMove.Add(node.South);
                    }
                }
                else if (node.South is { Type: NodeType.Splitter })
                {
                    SplitCount++;
                    // Prob need many
                    if (node.South?.East is not null)
                    {
                        //TotalNumberOfBeams += 1;
                        node.South.East.NumberOfBeams += node.NumberOfBeams;
                        if (NodesToMove.Contains(node.South.East) == false)
                        {
                            NodesToMove.Add(node.South.East);
                        }
                    }
                    if (node.South?.West is not null)
                    {
                        //TotalNumberOfBeams += 1;
                        node.South.West.NumberOfBeams += node.NumberOfBeams;
                        if (NodesToMove.Contains(node.South.West) == false)
                        {
                            NodesToMove.Add(node.South.West);
                        }
                    }
                }
            }

            StepIndex++;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            for (int y = 0; y < CurrentState.GetLength(0); y++)
            {
                for (int x = 0; x < CurrentState.GetLength(1); x++)
                {
                    sb.Append(CurrentState[y, x]);
                }

                if (y != CurrentState.GetLength(0) - 1)
                {
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }
    }

    public class Node
    {
        public NodeType Type { get; init; }

        public Vector2 Position { get; init; }

        public bool HasBeam => NumberOfBeams > 0;

        public long NumberOfBeams { get; set; }

        public Node? North { get; set; }

        public Node? NorthEast { get; set; }

        public Node? East { get; set; }

        public Node? SouthEast { get; set; }

        public Node? South { get; set; }

        public Node? SouthWest { get; set; }

        public Node? West { get; set; }

        public Node? NorthWest { get; set; }

        public override string ToString()
        {
            return HasBeam && Type != NodeType.Start
                ? "|"
                : Type switch
                {
                    NodeType.Empty => ".",
                    NodeType.Start => "S",
                    NodeType.Splitter => "^",
                    _ => throw new NotImplementedException(),
                };
        }
    }

    public enum NodeType
    {
        Empty,
        Start,
        Splitter
    }
}
