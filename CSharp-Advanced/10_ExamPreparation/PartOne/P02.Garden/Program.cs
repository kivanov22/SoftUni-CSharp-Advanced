using System;
using System.Linq;

namespace P02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];

            int[,] matrix = new int[n, m];//by default 0

           

            string command = Console.ReadLine();
            int flowerRow = 0;
            int flowerCol = 0;
            
            while (command != "Bloom Bloom Plow")
            {
                int[] cmdArgs = command.Split(" ").Select(int.Parse).ToArray();
                int currentRow = cmdArgs[0];
                int currentCol = cmdArgs[1];

                if (!isValidPosition(currentRow, currentCol, n,m))
                {
                    Console.WriteLine("Invalid coordinates.");
                    
                }
                flowerRow = currentRow;
                flowerCol = currentCol;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (i==flowerRow || j==flowerCol)
                        {
                            matrix[i, j] += 1;
                        }
                    }
                }


                command = Console.ReadLine();
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }

        }
        public static bool isValidPosition(int row, int col, int rows, int cols)
            {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }
            return true;
        }
      
    }
}
