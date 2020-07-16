using SudokuLibrary.Sudoku;
using System;
using System.Linq;

namespace SudokuLibrary.SudokuSolver
{
    public class SudokuSolverBruteForce : ISudokuSolver
    {
        private ISudoku workingSudoku;

        private bool isSolved = false;

        public ISudoku Solve(ISudoku Sudoku)
        {
            this.workingSudoku = Sudoku;

            var currentCell = workingSudoku.Cells[0][0];

            if (currentCell.IsFixed)
            {
                currentCell = FindNextUnfixedCell(currentCell);
            }

            while (!isSolved)
            {
                var overflow = Increment(currentCell);
                if (overflow)
                {
                    currentCell = FindNextUnfixedCell(currentCell, true);
                }
                else if (!HasErrors(currentCell))
                {
                    currentCell = FindNextUnfixedCell(currentCell);
                }
            }
                        
            return workingSudoku;
        }

        public bool TestError(ISudoku Sudoku, ICell Cell)
        {
            this.workingSudoku = Sudoku;
            return HasErrors(Cell);
        }

        private Boolean HasErrors(ICell cell)
        {
            var cellContainers = cell.getContainers();
            Boolean hasErrors = false;

            for (int i = 0; i < cellContainers.Count(); i++)
            {
                var listOfCellsInContainer = workingSudoku.getCellsInContainer(cellContainers[i]);

                listOfCellsInContainer.RemoveAll(cell => cell.Value == 0);

                if (listOfCellsInContainer.GroupBy(cell => cell.Value).Any(group => group.Count() > 1))
                {
                    hasErrors = true;
                    break;
                }
            }
            return hasErrors;
        }

        private ICell FindNextUnfixedCell(ICell currentCell, bool Previous = false)
        {
            int step = 1;
            int checkIndex = 0;

            if (Previous)
            {
                step = -1;
                checkIndex = 8;
            }

            int nextColumn = currentCell.Position[1];
            int nextRow = currentCell.Position[0];

            
            do
            {
                nextColumn = (int)Mod(nextColumn + step , workingSudoku.Size);

                if (nextColumn == checkIndex)
                {
                    nextRow = (int)Mod(nextRow + step,workingSudoku.Size);

                    if (nextRow == checkIndex)
                    {
                        isSolved = true;
                    }
                }
                currentCell = workingSudoku.Cells[nextRow][nextColumn];

            } while (currentCell.IsFixed);

            return currentCell;
        }

        private bool Increment(ICell currentCell)
        {
            currentCell.Value = (currentCell.Value + 1) % (workingSudoku.Size + 1);

            return currentCell.Value == 0;
        }

        private float Mod(float a, float b )
        {
            var result = a % b;

            if(result < 0)
            {
                result += b;
            }

            return result;
        }


    }
}
