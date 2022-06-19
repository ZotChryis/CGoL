# Conway's Game of Life Simulation (C# & Winforms)

This project has two implementations of Conway's Game of Life and was created in a total of 8h spread across two days for an interview test.

## Board.cs & Cell.cs
![cgol](https://user-images.githubusercontent.com/3958827/174498652-17a94e35-b90d-4fea-af3c-2729ef58449d.gif)
  - Stores the simulation in a 2D array.
    - Only supporting int32 coordinate space.
  - Size of the simulation is dictated by the size of the GUI's picture box.
  - GUI has buttons to create a variety of presets under the label _Presets_.
  - Simulation respects the _Step Time_ (milliseconds) from the GUI.
  - Simulation is visualized in the GUI's picture box.

## BigBoard.cs & BigBoard.cs
![cgol_bb](https://user-images.githubusercontent.com/3958827/174499276-7bb6636c-faca-4dbf-8798-282af37d99ee.gif)
  - Stores the simulation in a Sparse 2D array. 
    - Supporting int64 coordinate space.
    - Initially stored as nested dictionaries, which Sparse 2D array takes to another level for usability. 
    - Sparse 2D array implementation: https://www.codeproject.com/Articles/673055/Generic-Sparse-Array-and-Sparse-Matrices-in-Csharp
  - Size of the simulation is unrelated to the GUI.
  - GUI has buttons to create a variety of presets under the label _BigBoard_.
    - The sample input in the test question be spun up with the _Prompt_ button.
  - Simulation respects the _Step Time_ (milliseconds) from the GUI.
  - Simulation is **NOT** visualized in the GUI's picture box.
    - Board state is printed to the console log at every step of the simulation until it has no living cells.
   
# Potential Updates
- Inheritance structure to better encapsulate both simulations with a shared base.
- GUI support for BigBoard.
  - Needs drag support in the picture box to offset the visual representation of the simulation because of the large simulation space.
- GUI support for initial state construction.
- GUI support for save/load of initial states.
  - Requires a serializable version of the input data, currently there is none supported.
- Parallelization of lengthy calls like BidBoard.PreStepCells() and BigBoard.EvaluateCell() functions
