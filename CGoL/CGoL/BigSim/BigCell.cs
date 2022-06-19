namespace CGoL.BigSim
{
    /// <summary>
    /// Representation of a single element in the big simulation. 
    /// </summary>
    public class BigCell
    {
        public BigCell(long x, long y)
        {
            this.x = x;
            this.y = y;
            IsAlive = true;
        }

        /// <summary>
        /// The X location of this cell.
        /// </summary>
        public long x;

        /// <summary>
        /// The Y location of this cell.
        /// </summary>
        public long y;

        /// <summary>
        /// State of the cell's curent living status.
        /// </summary>
        public bool IsAlive;

        /// <summary>
        /// Stored state of the next state of the cell in the simulation.
        /// </summary>
        public bool WillBeAlive;
    }
}
