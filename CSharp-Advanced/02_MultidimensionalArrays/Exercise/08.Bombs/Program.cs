using System;

using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] rowData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            //1,2 2,1 2,0
            string[] coordinates = Console
                        .ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] splittedCoordinates = coordinates[i]
                          .Split(",")
                          .Select(int.Parse)
                          .ToArray();
                int bombRow = splittedCoordinates[0];
                int bombCol = splittedCoordinates[1];
                int bombPower = matrix[bombRow, bombCol];

                if (bombPower > 0)
                {
                    if (matrix[bombRow, bombCol] > 0)
                    {
                        if (isValid(matrix, bombRow - 1, bombCol - 1) && matrix[bombRow - 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol - 1] -= bombPower;//matrix[bombRow, bombCol];
                        }
                        if (isValid(matrix, bombRow - 1, bombCol) && matrix[bombRow - 1, bombCol] > 0)
                        {
                            matrix[bombRow - 1, bombCol] -= bombPower;
                        }
                        if (isValid(matrix, bombRow - 1, bombCol+1) && matrix[bombRow - 1, bombCol+1] > 0)
                        {
                            matrix[bombRow - 1, bombCol+1] -= bombPower;
                        }
                        if (isValid(matrix, bombRow , bombCol + 1) && matrix[bombRow, bombCol + 1] > 0)
                        {
                            matrix[bombRow , bombCol + 1] -= bombPower;
                        }
                        if (isValid(matrix, bombRow+1, bombCol + 1) && matrix[bombRow+1, bombCol + 1] > 0)
                        {
                            matrix[bombRow+1, bombCol + 1] -= bombPower;
                        }
                        if (isValid(matrix, bombRow+1, bombCol ) && matrix[bombRow+1, bombCol] > 0)
                        {
                            matrix[bombRow+1, bombCol] -= bombPower;
                        }
                        if (isValid(matrix, bombRow+1, bombCol -1 ) && matrix[bombRow+1, bombCol - 1] > 0)
                        {
                            matrix[bombRow+1, bombCol - 1] -= bombPower;
                        }
                        if (isValid(matrix, bombRow, bombCol - 1) && matrix[bombRow, bombCol - 1] > 0)
                        {
                            matrix[bombRow, bombCol - 1] -= bombPower;
                        }
                    }
                    matrix[bombRow, bombCol] = 0;
                }
            }
            Console.WriteLine($"Alive cells: {matrix.Cast<int>().Where(x => x > 0).Count().ToString()}");
            Console.WriteLine($"Sum: {matrix.Cast<int>().Where(x => x > 0).Sum().ToString()}");

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool isValid(int[,] matrix, int bombRow, int bombCol)
        {
            return bombRow >= 0 && bombRow < matrix.GetLength(0) && bombCol >= 0 && bombCol < matrix.GetLength(1);
        }
    }
}
