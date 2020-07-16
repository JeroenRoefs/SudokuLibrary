using System;
using System.Collections.Generic;

namespace SudokuLibrary.Sudoku
{
    public class CellSquare : ICell
    {
        public int Value { get; set; }

        public bool IsFixed { get; set; }
        public int[] Position { get; set; }
        public ISudoku ParentSudoku { get; set; }

        public CellSquare()
        {
            IsFixed = false;
            Position = new int[2];
        }

        public List<Container> getContainers()
        {
            var result = new List<Container>
            {
                getRow(),
                getColumn(),
                getSquare()
            };

            return result;
        }

        private Container getRow()
        {
            var rowContainer = new Container
            {
                ParentSudoku = ParentSudoku
            };

            for (int i = 0; i < ParentSudoku.Size; i++)
            {
                int nextPosition = (Position[0] + i) % ParentSudoku.Size;
                rowContainer.CellPositions.Add(new int[2] { nextPosition, Position[1] });
            }

            return rowContainer;
        }

        private Container getColumn()
        {
            var columnContainer = new Container
            {
                ParentSudoku = ParentSudoku
            };

            for (int i = 0; i < ParentSudoku.Size; i++)
            {
                int nextPosition = (Position[1] + i) % ParentSudoku.Size;
                columnContainer.CellPositions.Add(new int[2] { Position[0], nextPosition });
            }

            return columnContainer;
        }

        private Container getSquare()
        {
            var squareContainer = new Container
            {
                ParentSudoku = ParentSudoku
            };

            int squareSize = (int)Math.Sqrt(ParentSudoku.Size);
            int squareRowPosition = (int)(Position[0] / squareSize);
            int squareColumnPosition = (int)(Position[1] / squareSize);


            for (int i = 0; i < squareSize; i++)
            {
                for (int j = 0; j < squareSize; j++)
                {
                    int nextRowPosition = (Position[0] + i) % squareSize + squareRowPosition*squareSize;
                    int nextColumnPosition = (Position[1] + j) % squareSize + squareColumnPosition*squareSize;

                    squareContainer.CellPositions.Add(new int[2] { nextRowPosition, nextColumnPosition });
                }
            }

            return squareContainer;
        }
    }

}
