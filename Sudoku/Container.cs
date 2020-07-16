using System.Collections.Generic;

namespace SudokuLibrary.Sudoku
{
    public class Container
    {
        public List<int[]> CellPositions { get; set; }

        public ISudoku ParentSudoku { get; set; }

        public Container()
        {
            CellPositions = new List<int[]>();
        }

        public List<ICell> getCells()
        {
            var Cells = new List<ICell>();

            foreach (var Positions in CellPositions)
            {
                Cells.Add(ParentSudoku.Cells[Positions[0]][Positions[1]]);
            }

            return Cells;
        }

    }
}
