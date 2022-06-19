using SparseCollections;
using System.Collections.Generic;
using System.Text;

// TODO: Cleanup
namespace CGoL.BigSim
{
    /// <summary>
    /// The core of the simulation. The board maintains and updates all the cells in the simulation.
    /// This is a version that hopes to support larger simulations that encompass the 64-bit space.
    /// </summary>
    public class BigBoard
    {
        Dictionary<long, Dictionary<long, BigCell>> Cells;
        List<BigCell> CellsToAdd = new List<BigCell>();

        Sparse2DMatrix<long, long, BigCell> SparseCells;

        /// <summary>
        /// Creates a new big board. We assume the Int64 space.
        /// </summary>
        public BigBoard()
        {
            Cells = new Dictionary<long, Dictionary<long, BigCell>>();
            SparseCells = new Sparse2DMatrix<long, long, BigCell>();
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Live Cells:");

            foreach (KeyValuePair<ComparableTuple2<long, long>, BigCell> entry in SparseCells)
            {
                if (!entry.Value.IsAlive)
                {
                    continue;
                }

                long x = 0;
                long y = 0;
                SparseCells.SeparateCombinedKeys(entry.Key, ref x, ref y);

                sb.Append("X: " + x);
                sb.AppendLine(", Y: " + y);
            }

            /*
            foreach (KeyValuePair<long, Dictionary<long, BigCell>> entry in Cells)
            {
                foreach (KeyValuePair<long, BigCell> innerEntry in entry.Value)
                {
                    if (!innerEntry.Value.IsAlive)
                    {
                        continue;
                    }

                    sb.Append("X: ");
                    sb.Append(entry.Key.ToString());
                    sb.Append(", Y: ");
                    sb.AppendLine(innerEntry.Key.ToString());
                }
            }
            */

            return sb.ToString();
        }

        public void AddCell(long x, long y)
        {
            /*
            BigCell bigCell = new BigCell(x, y);

            if (!Cells.ContainsKey(x))
            {
                Cells.Add(x, new Dictionary<long, BigCell>());
            }

            if (!Cells[x].ContainsKey(y))
            {
                Cells[x].Add(y, bigCell);
            }
            */

            SparseCells[x, y] = new BigCell(x, y);
        }

        public void AddCell(BigCell bigCell)
        {
            /*
            if (!Cells.ContainsKey(bigCell.x))
            {
                Cells.Add(bigCell.x, new Dictionary<long, BigCell>());
            }

            if (!Cells[bigCell.x].ContainsKey(bigCell.y))
            {
                Cells[bigCell.x].Add(bigCell.y, null);
            }
            Cells[bigCell.x][bigCell.y] = bigCell;
            */

            SparseCells[bigCell.x, bigCell.y] = bigCell;
        }

        public int GetLiveCellCount()
        {
            int liveCells = 0;

            /*
            foreach (KeyValuePair<long, Dictionary<long, BigCell>> entry in Cells)
            {
                foreach (KeyValuePair<long, BigCell> innerEntry in entry.Value)
                {
                    if (!innerEntry.Value.IsAlive)
                    {
                        continue;
                    }

                    liveCells++;
                }
            }
            */

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

        public BigCell GetCell(long x, long y)
        {
            /*
            if (!Cells.ContainsKey(x))
            {
                return null;
            }

            if (!Cells[x].ContainsKey(y))
            {
                return null;
            }
            
            return Cells[x][y];
            */

            return SparseCells[x, y];
        }

        public BigCell GetCellToAdd(long x, long y)
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

        public void EvaluateIfAlive(long x, long y)
        {
            BigCell cell = GetCell(x, y);
            if (cell != null && cell.IsAlive)
            {
                int livingNeighbors = GetLiveNeighborCount(x, y);
                cell.WillBeAlive = livingNeighbors == 2 || livingNeighbors == 3;
            }
        }

        public void EvaluateIfDead(long x, long y)
        {
            BigCell cell = GetCell(x, y);
            if (cell != null && cell.IsAlive)
            {
                return;
            }

            cell = GetCellToAdd(x, y);
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

        public int GetLiveNeighborCount(long x, long y)
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

            /*
            // TODO: Clean up this function to be less nested
            int neighbors = 0;
            if (Cells.ContainsKey(x))
            {
                if (Cells[x].ContainsKey(y - 1))
                {
                    if (Cells[x][y - 1].IsAlive)
                    {
                        neighbors++;
                    }
                    
                }
                if (Cells[x].ContainsKey(y + 1))
                {
                    if (Cells[x][y + 1].IsAlive)
                    {
                        neighbors++;
                    }
                }
            }

            if (Cells.ContainsKey(x - 1))
            {
                if (Cells[x - 1].ContainsKey(y - 1))
                {
                    if (Cells[x - 1][y - 1].IsAlive)
                    {
                        neighbors++;
                    }
                }
                if (Cells[x - 1].ContainsKey(y))
                {
                    if (Cells[x - 1][y].IsAlive)
                    {
                        neighbors++;
                    }
                }
                if (Cells[x - 1].ContainsKey(y + 1))
                {
                    if (Cells[x - 1][y + 1].IsAlive)
                    {
                        neighbors++;
                    }
                }
            }

            if (Cells.ContainsKey(x + 1))
            {
                if (Cells[x + 1].ContainsKey(y - 1))
                {
                    if (Cells[x + 1][y - 1].IsAlive)
                    {
                        neighbors++;
                    }
                }
                if (Cells[x + 1].ContainsKey(y))
                {
                    if (Cells[x + 1][y].IsAlive)
                    {
                        neighbors++;
                    }
                }
                if (Cells[x + 1].ContainsKey(y + 1))
                {
                    if (Cells[x + 1][y + 1].IsAlive)
                    {
                        neighbors++;
                    }
                }
            }
            */

            return neighbors;
        }

        public void PreStep()
        {
            /*
            foreach (KeyValuePair<long, Dictionary<long, BigCell>> entry in Cells)
            {
                foreach (KeyValuePair<long, BigCell> innerEntry in entry.Value)
                {
                    //  Figure out the state for the current living cell
                    EvaluateIfAlive(innerEntry.Value.x, innerEntry.Value.y);

                    //  Find any neighboring dead cell and try to recessitate it!
                    EvaluateIfDead(innerEntry.Value.x - 1, innerEntry.Value.y - 1);
                    EvaluateIfDead(innerEntry.Value.x - 1, innerEntry.Value.y);
                    EvaluateIfDead(innerEntry.Value.x - 1, innerEntry.Value.y + 1);

                    EvaluateIfDead(innerEntry.Value.x, innerEntry.Value.y - 1);
                    EvaluateIfDead(innerEntry.Value.x, innerEntry.Value.y + 1);

                    EvaluateIfDead(innerEntry.Value.x + 1, innerEntry.Value.y - 1);
                    EvaluateIfDead(innerEntry.Value.x + 1, innerEntry.Value.y);
                    EvaluateIfDead(innerEntry.Value.x + 1, innerEntry.Value.y + 1);
                }
            }
            */

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

        public void Step()
        {
            foreach (KeyValuePair<ComparableTuple2<long, long>, BigCell> entry in SparseCells)
            {
                entry.Value.IsAlive = entry.Value.WillBeAlive;
            }

            /*
            foreach (KeyValuePair<long, Dictionary<long, BigCell>> entry in Cells)
            {
                foreach (KeyValuePair<long, BigCell> innerEntry in entry.Value)
                {
                    innerEntry.Value.IsAlive = innerEntry.Value.WillBeAlive;
                }
            }
            */

            foreach (BigCell cellToAdd in CellsToAdd)
            {
                AddCell(cellToAdd);
            }
            CellsToAdd.Clear();

            // TODO: Clean up any empty dictionaries to reduce memory footprint at the cost of extra operations
            //       onto the double-dictionaries
        }
    }
}
