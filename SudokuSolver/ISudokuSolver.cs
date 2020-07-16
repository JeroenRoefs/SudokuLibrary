using SudokuLibrary.Sudoku;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuLibrary.SudokuSolver
{
    public interface ISudokuSolver
    {
        public ISudoku Solve(ISudoku Sudoku);
    }
}
