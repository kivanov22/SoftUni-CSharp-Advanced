using System;
using System.Linq;

namespace _03.Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];


            for (int row = 0; row < n; row++)
            {
                int[] rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int sum = 0;

            for (int row = 0; row < 1; row++)
            {
                for (int col = 0; col < n; col++)
                {
                   

                    if (col==0)
                    {
                        sum += matrix[row, col];

                    }
                    else if (col==1)
                    {
                        sum += matrix[row+1, col];
                    }
                    else if (col==2)
                    {
                        sum += matrix[row + 2, col];
                    }
                    
                }
               Console.WriteLine(sum);
            }

        }
    }
}
