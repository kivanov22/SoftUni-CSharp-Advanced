using System;
using System.Linq;

namespace _02.Square_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            int n = dimensions[0];
            int m = dimensions[1];

            char[,] matrix = new char[n, m];

            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int countSquares = 0;

            for (int row = 0; row < n-1; row++)
            {
                for (int col = 0; col < m-1; col++)
                {
                    if (matrix[row,col]==matrix[row,col+1]&&
                        matrix[row,col]==matrix[row+1,col+1]&&
                        matrix[row,col]==matrix[row+1,col])
                    {
                        countSquares++;
                    }
                }
            }
            Console.WriteLine(countSquares);
        }
    }
}
