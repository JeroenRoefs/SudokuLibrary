using System.Collections.Generic;

namespace SudokuLibrary.Sudoku
{
    public interface ISudoku
    {
        public int Size { get; set; }
        public List<List<ICell>> Cells { get; }

        public void Solve();
        public void SetCells(int[,] Values);
        public void SetCell(int[] position, int Value);

        public List<ICell> getCellsInContainer(Container container);
        public void Display();
    }
    
    
}
