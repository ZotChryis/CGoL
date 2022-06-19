using System.Windows.Forms;

namespace CGoL
{
    /*
     *      Development Notes
     *      
     *      Day1:
     *      
     *      Never having implemented CGoL and forgetting how to use Winforms, I took the first 2.5 hours creating 
     *      a basic version fo CGoL and got it to display in a windform picture box. I took some basic patterns and
     *      hooked them to buttons.
     *      
     *      Next was thinking about the actual prompt of making the simulation work in 64 bit coordinate space.
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
     *      We can clean up dead cells to alleviate this concern at the cost of performance. Maybe only do this on 
     *      every 10th generation or so?
     *      
     *      Thoughts nearing the 5.5 hour mark:
     *      Is there a cleaner way to keep these dictionary records of only live cells? The only thing that I could
     *      come up with was using Sparse Arrays, which are essentially just dictionaries behind the scenes. They are
     *      not something I normally use, and .NET/MSDN doesn't have an officially supported data structure. I
     *      found an implementation online under the MIT license so I have imported it an an attempt and utilize them
     *      to clean up the dictionary backing of the BigBoard.
     *      
     *      Day 2:
     *      
     *      Spent an hour the second day (total so far being 6.5 hours) cleaning up the BigBoard's SparseMatrix2D 
     *      implementation. I'm at a point where things are working but there could be a lot more done. Seeing as
     *      I want to keep this project under 1 working day (8 hours), I will transition into making some documentation 
     *      for what is here.
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
