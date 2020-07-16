using System;
using System.IO;

namespace SudokuLibrary.SudokuReader
{
    public class SudokuReader1 : ISudokuReader
    {
        public string FilePath { get; set; }
        public int[,] GetSudoku()
        {
            string fileOutput = File.ReadAllText(FilePath);

            string[] stringSudokuArray = fileOutput.Replace("\r\n", "-").Replace('*','0').Split('-');

            int rowLength = (int)Math.Sqrt(stringSudokuArray.Length);

            int[,] SudokuArray = new int[rowLength, rowLength];

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    SudokuArray[i, j] = Convert.ToInt32(stringSudokuArray[i * rowLength + j]);
                }
            }

            return SudokuArray;
        }
    }
}
