using System.Collections.Generic;

namespace CGoL.Sim
{
    /// <summary>
    /// Representation of a single element in the simulation. 
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// State of the cell's curent living status.
        /// </summary>
        public bool IsAlive;

        /// <summary>
        /// Stored state of the next state of the cell in the simulation.
        /// </summary>
        private bool WillBeAlive;

        public List<Cell> neighbors = new List<Cell>();

        /// <summary>
        /// Called when the simulation is moved forward. Guaranteed to be called on all cells before the 
        /// finalization pass.
        /// </summary>
        public void PreStep()
        {
            // Rules of CGoL
            // 1) Any live cell with fewer than two live neighbours dies, as if by underpopulation.
            // 2) Any live cell with more than three live neighbours dies, as if by overpopulation.
            // 3) Any live cell with two or three live neighbours lives on to the next generation.
            // 4) Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

            int livingNeighbors = 0;
            foreach (Cell item in neighbors)
            {
                if (!item.IsAlive)
                {
                    continue;
                }

                livingNeighbors++;
            }

            if (IsAlive)
            {
                //  Technically this condition is the explicit version of the first 2 rules, but it can
                //  be reduced to a two equality comparisons representing the 3rd rule instead
                // WillBeAlive = livingNeighbors >= 2 && livingNeighbors <= 3;
                WillBeAlive = livingNeighbors == 2 || livingNeighbors == 3;
            }
            else
            {
                WillBeAlive = livingNeighbors == 3;
            }
        }

        /// <summary>
        /// The finalization pass of the simulation moving forward. All cells will have PreStep called first
        /// to prepare its next state.
        /// </summary>
        public void Step()
        {
            IsAlive = WillBeAlive;
        }
    }
}
