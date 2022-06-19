using JetBrains.Annotations;
using SparseCollections;
using System;
using System.Collections.Generic;
using System.Text;

namespace CGoL.BigSim
{
    /// <summary>
    /// The core of the simulation. The board maintains and updates all the cells in the simulation.
    /// This is a version that hopes to support larger simulations that encompass the 64-bit space.
    /// </summary>
    public class BigBoard
    {
        private const string c_BoardLabel = "BigBoard: ";
        private const string c_LiveCellsLabel = "Live Cells";
        private const string c_CoordinateXLabel = "X: ";
        private const string c_CoordinateYLabel = ", Y: ";

        List<BigCell> CellsToAdd = new List<BigCell>();

        Sparse2DMatrix<long, long, BigCell> SparseCells;

        /// <summary>
        /// Creates a new big board. We assume the Int64 space.
        /// </summary>
        public BigBoard()
        {
            SparseCells = new Sparse2DMatrix<long, long, BigCell>();
        }

        /// <summary>
        /// Used to display the state of the board at the end of every step.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(c_LiveCellsLabel);

            foreach (KeyValuePair<ComparableTuple2<long, long>, BigCell> entry in SparseCells)
            {
                if (!entry.Value.IsAlive)
                {
                    continue;
                }

                long x = 0;
                long y = 0;
                SparseCells.SeparateCombinedKeys(entry.Key, ref x, ref y);

                sb.Append(c_CoordinateXLabel);
                sb.Append(x.ToString());
                sb.Append(c_CoordinateYLabel);
                sb.AppendLine(y.ToString());
            }

            return sb.ToString();
        }

        // TODO: Reduce this to one signature
        /// <summary>
        /// Adds a new living cell at the given (x, y) coordinate to the simulation.
        /// </summary>
        public void AddCell(long x, long y)
        {
            SparseCells[x, y] = new BigCell(x, y);
        }

        public void AddCell(BigCell bigCell)
        {
            SparseCells[bigCell.x, bigCell.y] = bigCell;
        }

        /// <summary>
        /// Used to determine the end of the simulation at the end of every step.
        /// </summary>
        /// TODO: This can be a running count instead of iterating over the simulation
        private int GetLiveCellCount()
        {
            int liveCells = 0;

            foreach (KeyValuePair<ComparableTuple2<long, long>, BigCell> entry in SparseCells)
            {
                if (!entry.Value.IsAlive)
                {
                    continue;
                }
                liveCells++;
            }

            return liveCells;
        }

        /// <summary>
        /// Retrieves the cell at the given (x, y) coordinate.
        /// </summary>
        [CanBeNull]
        private BigCell GetCell(long x, long y)
        {
            return SparseCells[x, y];
        }

        // TODO: Can I get rid of this tracking list?
        private BigCell GetCellToBeAdded(long x, long y)
        {
            // TODO: Can this go away now with sparse arrays?
            foreach (BigCell cell in CellsToAdd)
            {
                if (cell.x == x && cell.y == y)
                {
                    return cell;
                }
            }

            return null;
        }

        // TODO: Reduce these two to one call?
        private void EvaluateIfAlive(long x, long y)
        {
            BigCell cell = GetCell(x, y);
            if (cell != null && cell.IsAlive)
            {
                int livingNeighbors = GetLiveNeighborCount(x, y);
                cell.WillBeAlive = livingNeighbors == 2 || livingNeighbors == 3;
            }
        }

        private void EvaluateIfDead(long x, long y)
        {
            BigCell cell = GetCell(x, y);
            if (cell != null && cell.IsAlive)
            {
                return;
            }

            cell = GetCellToBeAdded(x, y);
            if (cell != null && cell.IsAlive)
            {
                return;
            }

            int livingNeighbors = GetLiveNeighborCount(x, y);
            if (livingNeighbors == 3)
            {
                CellsToAdd.Add(new BigCell(x, y));
            }
        }

        private int GetLiveNeighborCount(long x, long y)
        {
            BigCell topLeft = SparseCells[x - 1, y - 1];
            BigCell topCenter = SparseCells[x, y - 1];
            BigCell topRight = SparseCells[x + 1, y - 1];
            BigCell left = SparseCells[x - 1, y];
            BigCell right = SparseCells[x + 1, y];
            BigCell bottomLeft = SparseCells[x - 1, y + 1];
            BigCell bottomCenter = SparseCells[x, y + 1];
            BigCell bottomRight = SparseCells[x + 1, y + 1];

            int neighbors = 0;
            if (topLeft != null && topLeft.IsAlive)
            {
                neighbors++;
            }
            if (topCenter != null && topCenter.IsAlive)
            {
                neighbors++;
            }
            if (topRight != null && topRight.IsAlive)
            {
                neighbors++;
            }
            if (left != null && left.IsAlive)
            {
                neighbors++;
            }
            if (right != null && right.IsAlive)
            {
                neighbors++;
            }
            if (bottomLeft != null && bottomLeft.IsAlive)
            {
                neighbors++;
            }
            if (bottomCenter != null && bottomCenter.IsAlive)
            {
                neighbors++;
            }
            if (bottomRight != null && bottomRight.IsAlive)
            {
                neighbors++;
            }

            return neighbors;
        }

        /// <summary>
        /// Advance the simulation forward one step.
        /// </summary>
        public void Step()
        {
            if (GetLiveCellCount() == 0)
            {
                return;
            }

            Console.WriteLine(c_BoardLabel);
            Console.WriteLine(ToString());
            PreStepCells();
            StepCells();
        }

        /// <summary>
        /// Prepare the active cells in the simulation for the next step. Also looks at neighboring cells to
        /// living cells in order to determine their status.
        /// </summary>
        private void PreStepCells()
        {
            foreach (KeyValuePair<ComparableTuple2<long, long>, BigCell> entry in SparseCells)
            {
                long x = 0;
                long y = 0;
                SparseCells.SeparateCombinedKeys(entry.Key, ref x, ref y);

                //  Figure out the state for the current living cell
                EvaluateIfAlive(x, y);

                //  Find any neighboring dead cell and try to recessitate it!
                EvaluateIfDead(x - 1, y - 1);
                EvaluateIfDead(x - 1, y);
                EvaluateIfDead(x - 1, y + 1);

                EvaluateIfDead(x, y - 1);
                EvaluateIfDead(x, y + 1);

                EvaluateIfDead(x + 1, y - 1);
                EvaluateIfDead(x + 1, y);
                EvaluateIfDead(x + 1, y + 1);
            }
        }

        /// <summary>
        /// Finalizes the step in the simulation.
        /// </summary>
        private void StepCells()
        {
            foreach (KeyValuePair<ComparableTuple2<long, long>, BigCell> entry in SparseCells)
            {
                entry.Value.IsAlive = entry.Value.WillBeAlive;
            }

            // TODO: remove the need for this step
            foreach (BigCell cellToAdd in CellsToAdd)
            {
                AddCell(cellToAdd);
            }
            CellsToAdd.Clear();
        }
    }
}
