using System.Collections.Generic;

namespace SudokuLibrary.Sudoku
{
    public interface ICell
    {
        bool IsFixed { get; set; }
        ISudoku ParentSudoku { get; set; }
        int[] Position { get; set; }
        int Value { get; set; }

        List<Container> getContainers();
    }
}