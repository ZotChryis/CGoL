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

        /// <summary>
        /// The cells that are active in the simulation.
        /// </summary>
        Sparse2DMatrix<long, long, BigCell> Cells;

        /// <summary>
        /// The cells that will be active in the simulation.
        /// </summary>
        Sparse2DMatrix<long, long, BigCell> NewBornCells;

        /// <summary>
        /// Re-usable list of cells that are marked dead and must be removed from the cell matrix.
        /// </summary>
        List<ComparableTuple2<long, long>> DeadCells;

        /// <summary>
        /// Creates a new big board. We assume the Int64 space.
        /// </summary>
        public BigBoard()
        {
            Cells = new Sparse2DMatrix<long, long, BigCell>();
            NewBornCells = new Sparse2DMatrix<long, long, BigCell>();
            DeadCells = new List<ComparableTuple2<long, long>>();
        }

        /// <summary>
        /// Used to display the state of the board at the end of every step.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(c_LiveCellsLabel);

            foreach (KeyValuePair<ComparableTuple2<long, long>, BigCell> entry in Cells)
            {
                if (!entry.Value.IsAlive)
                {
                    continue;
                }

                long x = 0;
                long y = 0;
                Cells.SeparateCombinedKeys(entry.Key, ref x, ref y);

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
            Cells[x, y] = new BigCell();
        }

        /// <summary>
        /// Used to determine the end of the simulation at the end of every step.
        /// </summary>
        private int GetLiveCellCount()
        {
            //  All dead cells are removed from the simulation at the end of every step.
            //  If that ever changes, we must revert back to stepping through the dictionaries
            //  and filtering our any !IsAlive cells.
            return Cells.Count;
        }

        /// <summary>
        /// Retrieves the cell at the given (x, y) coordinate.
        /// </summary>
        [CanBeNull]
        private BigCell GetCell(long x, long y)
        {
            return Cells[x, y];
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
            foreach (KeyValuePair<ComparableTuple2<long, long>, BigCell> entry in Cells)
            {
                long x = 0;
                long y = 0;
                Cells.SeparateCombinedKeys(entry.Key, ref x, ref y);

                //  Figure out the state for the current living cell
                EvaluateCell(x, y);

                //  Find any neighboring dead cell and try to reroduce
                EvaluateCell(x - 1, y - 1);
                EvaluateCell(x - 1, y);
                EvaluateCell(x - 1, y + 1);

                EvaluateCell(x, y - 1);
                EvaluateCell(x, y + 1);

                EvaluateCell(x + 1, y - 1);
                EvaluateCell(x + 1, y);
                EvaluateCell(x + 1, y + 1);
            }
        }

        /// <summary>
        /// Determines the WillBeAlive status of any living cell.
        /// Also marks newborn cells to be added if the cell in question is missing from the simulation.
        /// </summary>
        private void EvaluateCell(long x, long y)
        {
            int livingNeighbors = GetLiveNeighborCount(x, y);
            BigCell cell = GetCell(x, y);
            if (cell != null && cell.IsAlive)
            {
                cell.WillBeAlive = livingNeighbors == 2 || livingNeighbors == 3;
            }
            else if (cell == null)
            {
                if (livingNeighbors == 3)
                {
                    NewBornCells[x, y] = new BigCell();
                }
            }
        }

        /// <summary>
        /// Returns the amount of living neighbors for the cell in the given (x, y) coordinate. 
        /// </summary>
        private int GetLiveNeighborCount(long x, long y)
        {
            int livingNeighbors = 0;
            for (long xCoordinate = x - 1; xCoordinate <= x + 1; xCoordinate++)
            {
                for (long yCoordinate = y - 1; yCoordinate <= y + 1; yCoordinate++)
                {
                    //  Skip itself
                    //  Note: We could start at -1 living neighbors to save on 9 comparisons
                    //  per call, but this way is more explicit.
                    if (xCoordinate == x && yCoordinate == y)
                    {
                        continue;
                    }

                    BigCell cell = Cells[xCoordinate, yCoordinate];
                    if (cell != null && cell.IsAlive)
                    {
                        livingNeighbors++;
                    }
                }
            }

            return livingNeighbors;
        }

        /// <summary>
        /// Finalizes the step in the simulation.
        /// </summary>
        private void StepCells()
        {
            //  Finalize the state of living cells in the simulation
            foreach (KeyValuePair<ComparableTuple2<long, long>, BigCell> entry in Cells)
            {
                entry.Value.IsAlive = entry.Value.WillBeAlive;

                //  Keep track of cells that need to be removed
                if (!entry.Value.IsAlive)
                {
                    DeadCells.Add(entry.Key);
                }
            }

            //  Add in any newborn cells to the simulation
            foreach (KeyValuePair<ComparableTuple2<long, long>, BigCell> entry in NewBornCells)
            {
                long x = 0;
                long y = 0;
                Cells.SeparateCombinedKeys(entry.Key, ref x, ref y);

                Cells[x, y] = NewBornCells[x, y];
            }
            NewBornCells.Clear();

            //  Remove any dead cells from the simulation
            foreach (ComparableTuple2<long, long> deadCell in DeadCells)
            {
                Cells.Remove(deadCell.Item0, deadCell.Item1);
            }
            DeadCells.Clear();
        }
    }
}
