using System.Windows.Forms;

namespace CGoL
{
    /*
     *      Development Notes:
     *      
     *      Never having implemented CGoL and forgetting how to use Winforms, I took the first 2.5 hours creating 
     *      a basic version fo CGoL and got it to display in a windform picture box. I took some basic patterns and
     *      hooked them to buttons.
     *      
     *      Next was thinking about the actual prompt of making the simulation work in 64 bit coordinates. 
     *      The limiting factor of making the simulation run is how to store the grid of cells.
     *      A trivial solution (found in Board.cs/Cell.cs) was to just store cells in a 2D array. However,
     *      arrays have a maximum storage limit of ~2GB (32 bit coordinate space) so that is not enough for the exercise.
     *      
     *      So we must find a better way to store the state of the grid of cells. Since we know that most of the cells
     *      will just be dead, it's best we just store information on the living cells. However, calculating neighbors 
     *      this way would lead to O(N^2) passes through live cells to determine the live stat of every cell.
     *      I can achieve this with a dictionary of dictionaries, although that still doesn't seem quite performant?
     *      
     *      A dictionary of dictionaries keeping only records of live cells allows us to have signed long x,y 
     *      coordinates, but at the cost of complex board handling. I also fear that eventually the dictionaries
     *      can get overwhelmed in memory capacity if eventually 50% of the simulation space is alive (or has been).
     *      We can clean up dead cells to alleviate this concern at the cost of performance.
     *      
     *      Thoughts nearing the 5 hour mark....
     *      Is there a cleaner way to keep these dictionary records of only live cells? The only thing that I could
     *      come up with was using Sparse Arrays, which are essentially just dictionaries behind the scenes. They are
     *      not something I normally use, and .NET/MSDN doesn't have these as officially supported data structures. I
     *      found an implementation online under the MIT license so I have imported it to attempt and utilize them
     *      to clean up the dictionary backing of the BigBoard.
     * 
     */

    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
