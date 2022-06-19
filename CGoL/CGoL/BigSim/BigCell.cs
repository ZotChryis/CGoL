namespace CGoL.BigSim
{
    // TODO: This can be a base that Cell inherets from

    /// <summary>
    /// Representation of a single element in the big simulation. 
    /// </summary>
    public class BigCell
    {
        public BigCell()
        {
            IsAlive = true;
            WillBeAlive = false;
        }

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
