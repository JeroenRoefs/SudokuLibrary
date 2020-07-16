using SudokuLibrary.Sudoku;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuLibrary.SudokuReader
{
    public interface ISudokuReader
    {
        public int[,] GetSudoku();
    }
}
