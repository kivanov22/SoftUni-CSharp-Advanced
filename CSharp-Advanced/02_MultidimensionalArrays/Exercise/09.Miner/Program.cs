using System;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] moves = Console.ReadLine().Split(" ").ToArray();

            char[,] matrix = new char[n, n];

            int minerRow = 0;
            int minerCol = 0;

            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console
                          .ReadLine()
                          .Split(" ")
                          .Select(char.Parse)
                          .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }

                }
            }
            bool IsInRange = false;
            int countCoal = 0;
            int rowIndex = 0;
            int colIndex = 0;
            char letter = ' ';
            foreach (var move in moves)
            {
                switch (move)
                {
                    case "up":
                        if (IsInside(matrix, minerRow - 1, minerCol))
                        {
                            IsInRange = true;
                            letter = matrix[minerRow - 1, minerCol];
                            rowIndex = minerRow - 1;
                            colIndex = minerCol;
                            minerRow -= 1;

                        }
                        break;
                    case "down":
                        if (IsInside(matrix, minerRow + 1, minerCol))
                        {
                            IsInRange = true;
                            letter = matrix[minerRow + 1, minerCol];
                            rowIndex = minerRow + 1;
                            colIndex = minerCol;
                            minerRow += 1;
                        }
                        break;
                    case "right":
                        if (IsInside(matrix, minerRow, minerCol + 1))
                        {
                            IsInRange = true;
                            letter = matrix[minerRow, minerCol + 1];
                            rowIndex = minerRow;
                            colIndex = minerCol + 1;
                            minerCol += 1;
                        }
                        break;
                    case "left":
                        if (IsInside(matrix, minerRow, minerCol - 1))
                        {
                            IsInRange = true;
                            letter = matrix[minerRow, minerCol - 1];
                            rowIndex = minerRow;
                            colIndex = minerCol - 1;
                            minerCol -= 1;
                        }
                        break;
                }
                if (IsInRange)
                {
                    if (letter == 'c')
                    {
                        matrix[minerRow, minerCol] = '*';
                    }
                    if (letter == 'e')
                    {
                        Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                        return;
                    }
                }
            }
            int countCoalsLeft = matrix.Cast<char>().Count(symbol => symbol == 'c');

            Console.WriteLine(countCoalsLeft == 0
                ? $"You collected all coals! ({rowIndex}, {colIndex})"
                : $"{countCoalsLeft} coals left. ({rowIndex}, {colIndex})");
        }
        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
               && col >= 0 && col < matrix.GetLength(1);
        }
    }
}