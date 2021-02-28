using System;
using System.Linq;

namespace _04.Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];

            string[,] matrix = new string[n, m];

            for (int row = 0; row < n; row++)
            {
                string[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }


           

            while (true)
            { 
                string command = Console.ReadLine();

                if (command=="END")
                {
                    break;
                }
                string[] tokens = command.Split(" ");


                if (tokens.Length != 5 || tokens[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    //command = Console.ReadLine();
                    continue;
                }

                int rowOne = int.Parse(tokens[1]);
                int colOne = int.Parse(tokens[2]);
                int rowTwo = int.Parse(tokens[3]);
                int colTwo = int.Parse(tokens[4]);

                bool isValidOne = isValidCell(rowOne, rowTwo, n, m);
                //rowOne >= 0 && rowOne < n && colOne >= 0 && colOne < m;
                //check validations
                bool isValidTwo = isValidCell(rowTwo, colTwo, n, m);
                    //rowTwo >= 0 && rowTwo < n && colTwo >= 0 && colTwo < m;

                if (!isValidOne || !isValidTwo)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                //bool isOutOfMatrix = rowOne < 0 || rowOne >= n || colOne < 0 || colOne >= m; other method for validation

                string valueOne = matrix[rowOne, colOne];//swap values 
                string valueTwo = matrix[rowTwo, colTwo];

                matrix[rowOne, colOne] = valueTwo;
                matrix[rowTwo, colTwo] = valueOne;

                PrintMatrix(matrix);

                //command = Console.ReadLine();
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool isValidCell(int row, int col, int n, int m)
        {
            return row >= 0 && row < n && col >= 0 && col < m;
        }
    }
}
