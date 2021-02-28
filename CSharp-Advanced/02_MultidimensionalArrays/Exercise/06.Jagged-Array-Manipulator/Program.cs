using System;
using System.Linq;

namespace _06.Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] matrix = new double[n][];

            for (int row = 0; row < n; row++)
            {
                double[] rowData = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
                matrix[row] = rowData;//this or with for to fill the rows, and we can take the Console readline and put it here and delete upper code
                                      //we need to create a new matrix
                                      //new int[rowData.Length]

                //for (int col = 0; col < rowData.Length; col++)
                //{

                //    matrix[row][col] = rowData[col];

                //above code is same as below two options here

                //  //var ads = matrix[col];
                //  //ads[col] = rowData[col];
                //}
            }

            for (int row = 0; row < n - 1; row++)
            {
                double[] firstArray = matrix[row];
                double[] secondArray = matrix[row + 1];

                if (firstArray.Length == secondArray.Length)
                {
                    matrix[row] = firstArray.Select(e => e * 2).ToArray();
                    matrix[row + 1] = secondArray.Select(e => e * 2).ToArray();
                }
                else
                {
                    matrix[row] = firstArray.Select(e => e / 2).ToArray();
                    matrix[row + 1] = secondArray.Select(e => e / 2).ToArray();
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArgs = command.Split(" ");
                int rowIndex = int.Parse(cmdArgs[1]);
                int colIndex = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                bool isValid = rowIndex >= 0 && rowIndex < n && colIndex >= 0 && colIndex < matrix[rowIndex].Length;

                if (!isValid)
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (cmdArgs[0] == "Add")
                {
                    
                    matrix[rowIndex][colIndex] += value;
                }
                else if (cmdArgs[0] == "Subtract")
                {
                    
                    matrix[rowIndex][colIndex] -= value;
                }
                command = Console.ReadLine();
            }

            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(string.Join(" ",matrix[row]));
            }
        }
    }
}
