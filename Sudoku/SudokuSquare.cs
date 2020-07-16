using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SudokuLibrary.Sudoku
{
    public class SudokuSquare : ISudoku
    {
        public int Size { get; set; }
        public List<List<ICell>> Cells { get; }


        public SudokuSquare()
        {
            Cells = new List<List<ICell>>();
        }

        public void Solve()
        {
            Console.WriteLine("Solved it!");
        }

        public void SetCells(int[,] Values)
        {
            Size = Values.GetLength(0);

            for (int i = 0; i < Size; i++)
            {

                Cells.Add(new List<ICell>());

                for (int j = 0; j < Size; j++)
                {
                    Cells[i].Add(new CellSquare()
                    {
                        Value = Values[i, j],
                        ParentSudoku = this
                    }) ;
                    Cells[i][j].Position = new int[2] { i, j };
                    if (Values[i, j] != 0)
                    {
                        Cells[i][j].IsFixed = true;
                    }

                }
            }

        }

        public void SetCell(int[] position, int Value)
        {
            Cells[position[0]][position[1]].Value = Value;
        }

        public List<ICell> getCellsInContainer(Container container)
        {
            List<ICell> cellsInContainer = new List<ICell>();

            foreach (var position in container.CellPositions)
            {
                cellsInContainer.Add(Cells[position[0]][position[1]]);
            }

            return cellsInContainer;
        }

        public void Display()
        {
            var squareSize =  (int)Math.Sqrt(Size);

            for (int i = 0; i < Cells.Count; i++)
            {
                Console.Write("|");
                for (int j = 0; j < Cells[i].Count; j++)
                {

                    Console.Write(" " + Cells[i][j].Value + " |");
                    if ((j+1)%squareSize == 0)
                    {
                        Console.Write("|");
                    }
                }

                Console.WriteLine();
                
                Console.WriteLine(new string('-', (squareSize*4+1)*squareSize+1));
                if ((i + 1) % squareSize == 0)
                {
                    Console.WriteLine(new string('-', (squareSize * 4 + 1) * squareSize + 1));
                }
            }
        }
    }


}
