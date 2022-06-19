using CGoL.Sim;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using CGoL.BigSim;

namespace CGoL
{
    /// <summary>
    /// Main container class for the GUI.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The size of each cell in pixels (width and height).
        /// </summary>
        private const int c_CellSize = 5;

        /// <summary>
        /// The simulated board of CGoL that is drawn to render target.
        /// </summary>
        private Board Board;

        /// <summary>
        /// The simulated board of CGoL that allows for 64-bit coordinate space.
        /// DOES NOT draw onto the GUI, instead it prints the state of the board into console.
        /// </summary>
        private BigBoard BigBoard;

        public Form1()
        {
            InitializeComponent();
            Reset();
            ResetBigBoard();
        }

        #region Shared

        /// <summary>
        /// Advances the simulation step at every timer tick.
        /// </summary>
        private void SimulationTimer_Tick(object sender, EventArgs e)
        {
            Board.Step();
            BigBoard.Step();

            Draw();
        }

        /// <summary>
        /// Changes the interval at which the simulation is stepped through.
        /// </summary>
        private void StepTimePicker_ValueChanged(object sender, EventArgs e)
        {
            SimulationTimer.Interval = (int)StepTimePicker.Value;
        }

        #endregion

        #region Board

        /// <summary>
        /// Clears out the current CGoL simulation.
        /// </summary>
        private void Reset()
        {
            Board = new Board(RenderTarget.Width, RenderTarget.Height, c_CellSize, true);
            Draw();
        }

        /// <summary>
        /// Clears out the current CGoL simulation, then begins a new one with the given living cells.
        /// </summary>
        /// <param name="offsetToCenter">If true, shift the cell locations to be in the center of the
        /// render target of the GUI.</param>
        private void Reset(List<Board.CellLocation> liveCellTuples, bool offsetToCenter = true) 
        {
            Reset();

            int offsetX = 0;
            int offsetY = 0;
            if (offsetToCenter)
            {
                //  Iterate through to find the minimum and maximum x and y values
                //  Note: This O(N) search can be eliminated if the input data was aware and provided these values
                int minX = int.MaxValue;
                int minY = int.MaxValue;
                int maxX = int.MinValue;
                int maxY = int.MinValue;

                foreach (Board.CellLocation item in liveCellTuples)
                {
                    if (item.x < minX)
                    {
                        minX = item.x;
                    }

                    if (item.y < minY)
                    {
                        minY = item.y;
                    }

                    if (item.x > maxX)
                    {
                        maxX = item.x;
                    }

                    if (item.y > maxY)
                    {
                        maxY = item.y;
                    }
                }

                //  Determine offsets so that the resulting simulation is centered in the board
                offsetX = (Board.Columns - (maxX - minX)) / 2;
                offsetY = (Board.Rows - (maxY - minY)) / 2;
            }

            foreach (Board.CellLocation item in liveCellTuples)
            {
                Board.Cells[item.x + offsetX, item.y + offsetY].IsAlive = true;
            }
        }

        /// <summary>
        /// Renders the state of the simulation into the RenderTarget's image.
        /// </summary>
        private void Draw()
        {
            using (var fillBrush = new SolidBrush(Color.Black))
            using (var bitmap = new Bitmap(Board.Width, Board.Height))
            using (var render = Graphics.FromImage(bitmap))
            {
                //  Make the background a solid color
                render.Clear(Color.GhostWhite);

                //  Determine the squares to draw on top
                Size cellSize = new Size(Board.CellSize, Board.CellSize);
                for (int col = 0; col < Board.Columns; col++)
                {
                    for (int row = 0; row < Board.Rows; row++)
                    {
                        Cell cell = Board.Cells[col, row];
                        if (cell.IsAlive)
                        {
                            Point cellLocation = new Point(col * Board.CellSize, row * Board.CellSize);
                            Rectangle cellRect = new Rectangle(cellLocation, cellSize);
                            render.FillRectangle(fillBrush, cellRect);
                        }
                    }
                }

                //  Draw the resulting image to our render target
                RenderTarget.Image = (Bitmap)bitmap.Clone();
            }
        }

        // Example patterns taken from: https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life#Examples_of_patterns
        // TODO: Make a file format that can be serialized for patterns
        // TODO: Make a GUI editor for making this file format
        private void BlinkersButton_Click(object sender, EventArgs e)
        {
            List<Board.CellLocation> liveCells = new List<Board.CellLocation>()
            {
                new Board.CellLocation {x = 0, y = 0 },
                new Board.CellLocation {x = 0, y = 1 },
                new Board.CellLocation {x = 0, y = 2 },

                new Board.CellLocation {x = 4, y = 0 },
                new Board.CellLocation {x = 4, y = 1 },
                new Board.CellLocation {x = 4, y = 2 },

                new Board.CellLocation {x = 8, y = 0 },
                new Board.CellLocation {x = 8, y = 1 },
                new Board.CellLocation {x = 8, y = 2 },
            };
            Reset(liveCells);
        }

        private void GliderButton_Click(object sender, EventArgs e)
        {
            List<Board.CellLocation> liveCells = new List<Board.CellLocation>()
            {
                new Board.CellLocation {x = 1, y = 0 },
                new Board.CellLocation {x = 2, y = 1 },
                new Board.CellLocation {x = 0, y = 2 },
                new Board.CellLocation {x = 1, y = 2 },
                new Board.CellLocation {x = 2, y = 2 }
            };
            Reset(liveCells);
        }

        private void GunButton_Click(object sender, EventArgs e)
        {
            List<Board.CellLocation> liveCells = new List<Board.CellLocation>()
            {
                new Board.CellLocation {x = 13, y = 8 },

                new Board.CellLocation {x = 12, y = 7 },
                new Board.CellLocation {x = 14, y = 7 },

                new Board.CellLocation {x = 0, y = 6 },
                new Board.CellLocation {x = 1, y = 6 },
                new Board.CellLocation {x = 11, y = 6 },
                new Board.CellLocation {x = 15, y = 6 },
                new Board.CellLocation {x = 16, y = 6 },
                new Board.CellLocation {x = 25, y = 6 },

                new Board.CellLocation {x = 0, y = 5 },
                new Board.CellLocation {x = 1, y = 5 },
                new Board.CellLocation {x = 11, y = 5 },
                new Board.CellLocation {x = 15, y = 5 },
                new Board.CellLocation {x = 16, y = 5 },
                new Board.CellLocation {x = 22, y = 5 },
                new Board.CellLocation {x = 23, y = 5 },
                new Board.CellLocation {x = 24, y = 5 },
                new Board.CellLocation {x = 25, y = 5 },
                
                new Board.CellLocation {x = 11, y = 4 },
                new Board.CellLocation {x = 15, y = 4 },
                new Board.CellLocation {x = 16, y = 4 },
                new Board.CellLocation {x = 21, y = 4 },
                new Board.CellLocation {x = 22, y = 4 },
                new Board.CellLocation {x = 23, y = 4 },
                new Board.CellLocation {x = 24, y = 4 },
                new Board.CellLocation {x = 34, y = 4 },
                new Board.CellLocation {x = 35, y = 4 },

                new Board.CellLocation {x = 12, y = 3 },
                new Board.CellLocation {x = 14, y = 3 },
                new Board.CellLocation {x = 21, y = 3 },
                new Board.CellLocation {x = 24, y = 3 },
                new Board.CellLocation {x = 34, y = 3 },
                new Board.CellLocation {x = 35, y = 3 },

                new Board.CellLocation {x = 13, y = 2 },
                new Board.CellLocation {x = 21, y = 2 },
                new Board.CellLocation {x = 22, y = 2 },
                new Board.CellLocation {x = 23, y = 2 },
                new Board.CellLocation {x = 24, y = 2 },
                new Board.CellLocation {x = 30, y = 2 },

                new Board.CellLocation {x = 22, y = 1 },
                new Board.CellLocation {x = 23, y = 1 },
                new Board.CellLocation {x = 24, y = 1 },
                new Board.CellLocation {x = 25, y = 1 },
                new Board.CellLocation {x = 30, y = 1 },

                new Board.CellLocation {x = 25, y = 0 },
            };

            Reset(liveCells);
        }

        private void AcornButton_Click(object sender, EventArgs e)
        {
            List<Board.CellLocation> liveCells = new List<Board.CellLocation>()
            {
                new Board.CellLocation {x = 2, y = 0 },
                new Board.CellLocation {x = 4, y = 1 },
                new Board.CellLocation {x = 1, y = 2 },
                new Board.CellLocation {x = 2, y = 2 },
                new Board.CellLocation {x = 5, y = 2 },
                new Board.CellLocation {x = 6, y = 2 },
                new Board.CellLocation {x = 7, y = 2 }
            };

            Reset(liveCells);
        }

        /// <summary>
        /// Resets the simulation whenever the render target bounds are changed.
        /// TODO: Make this non-disruptive by calculating the new image instead of forcing a reset.
        /// </summary>
        private void RenderTarget_SizeChanged(object sender, EventArgs e)
        {
            Reset();
        }

        #endregion

        #region BigBoard

        private void ResetBigBoard()
        {
            BigBoard = new BigBoard();
        }

        private void BigBlinkersButton_Click(object sender, EventArgs e)
        {
            ResetBigBoard();

            BigBoard.AddCell(0, 0);
            BigBoard.AddCell(0, 1);
            BigBoard.AddCell(0, 2);
            BigBoard.AddCell(4, 0);
            BigBoard.AddCell(4, 1);
            BigBoard.AddCell(4, 2);
            BigBoard.AddCell(8, 0);
            BigBoard.AddCell(8, 1);
            BigBoard.AddCell(8, 2);
        }

        private void BigAcornButton_Click(object sender, EventArgs e)
        {
            ResetBigBoard();

            BigBoard.AddCell(2, 0);
            BigBoard.AddCell(4, 1);
            BigBoard.AddCell(1, 2);
            BigBoard.AddCell(2, 2);
            BigBoard.AddCell(5, 2);
            BigBoard.AddCell(6, 2);
            BigBoard.AddCell(7, 2);
        }

        private void PromptButton_Click(object sender, EventArgs e)
        {
            ResetBigBoard();

            BigBoard.AddCell(0, 1);
            BigBoard.AddCell(1, 2);
            BigBoard.AddCell(2, 0);
            BigBoard.AddCell(2, 1);
            BigBoard.AddCell(2, 2);
            BigBoard.AddCell(-2000000000000, -2000000000000);
            BigBoard.AddCell(-2000000000001, -2000000000001);
        }

        #endregion
    }
}