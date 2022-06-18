using System;

namespace CGoL.Sim
{
    /// <summary>
    /// The core of the simulation. The board maintains and updates all the cells in the simulation.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Tuple to define a location in the simulation.
        /// </summary>
        public struct CellLocation
        {
            public int x;
            public int y;
        }

        /// <summary>
        /// All the cells in the simulation.
        /// </summary>
        public readonly Cell[,] Cells;

        /// <summary>
        /// Pixel length/width of each cell to be displayed.
        /// </summary>
        public readonly int CellSize;

        /// <summary>
        /// Amount of cell columns in the board.
        /// </summary>
        public int Columns => Cells.GetLength(0);

        /// <summary>
        /// Amount of cell rows in the board.
        /// </summary>
        public int Rows => Cells.GetLength(1);

        /// <summary>
        /// The width in total pixel count of the board.
        /// </summary>
        public int Width => Columns * CellSize;

        /// <summary>
        /// The height in total pixel count of the board.
        /// </summary>
        public int Height => Rows * CellSize;

        /// <summary>
        /// Creates a new board with the given dimensions.
        /// </summary>
        /// <param name="wrapWorld">Whether or not to wrap the the simulation space at the edges.</param>
        public Board(int width, int height, int cellSize, bool wrapWorld)
        {
            CellSize = cellSize;

            Cells = new Cell[width / cellSize, height / cellSize];
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    Cells[x, y] = new Cell();
                }
            }

            DetermineNeighbors(wrapWorld);
        }

        /// <summary>
        /// Connects all cells with its neighbors for faster lookups during the simulation.
        /// Assumes all cells have been created.
        /// </summary>
        private void DetermineNeighbors(bool wrapWorld)
        {
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    bool isLeftEdge = (x == 0);
                    bool isRightEdge = (x == Columns - 1);
                    bool isTopEdge = (y == 0);
                    bool isBottomEdge = (y == Rows - 1);
                    bool isEdge = isLeftEdge | isRightEdge | isTopEdge | isBottomEdge;

                    if (!wrapWorld && isEdge)
                    {
                        continue;
                    }

                    int leftX   = isLeftEdge ? Columns - 1 : x - 1;
                    int rightX  = isRightEdge ? 0 : x + 1;
                    int topY    = isTopEdge ? Rows - 1 : y - 1;
                    int bottomY = isBottomEdge ? 0 : y + 1;

                    Cells[x, y].neighbors.Add(Cells[leftX, topY]);
                    Cells[x, y].neighbors.Add(Cells[x, topY]);
                    Cells[x, y].neighbors.Add(Cells[rightX, topY]);
                    Cells[x, y].neighbors.Add(Cells[leftX, y]);
                    Cells[x, y].neighbors.Add(Cells[rightX, y]);
                    Cells[x, y].neighbors.Add(Cells[leftX, bottomY]);
                    Cells[x, y].neighbors.Add(Cells[x, bottomY]);
                    Cells[x, y].neighbors.Add(Cells[rightX, bottomY]);
                }
            }
        }

        /// <summary>
        /// The process of moving the simulation forward.
        /// </summary>
        // TODO: Is there a way to not interate over twice O(2N) ?
        public void Step()
        {
            foreach (Cell cell in Cells)
            {
                cell.PreStep();
            }

            foreach (Cell cell in Cells)
            {
                cell.Step();
            }
        }
    }
}
