using System;

namespace P02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int beeRow = 0;
            int beeCol = 0;

            for (int rows = 0; rows < n; rows++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = rowData[cols];

                    if (matrix[rows, cols] == 'B')
                    {
                        beeRow = rows;
                        beeCol = cols;
                    }
                }
            }


            string command = Console.ReadLine();
            int flowers = 0;
            

            while (command !="End")
            {
                matrix[beeRow, beeCol] = '.';
                beeRow = MoveRow(beeRow, command);
                beeCol = MoveCol(beeCol, command);

                if (!isInside(beeRow, beeCol, n, n))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                if (matrix[beeRow, beeCol] =='f')
                {
                    flowers++;
                }
                if (matrix[beeRow, beeCol] =='O')
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow = MoveRow(beeRow, command);
                    beeCol = MoveCol(beeCol, command);

                    if (!isInside(beeRow, beeCol, n, n))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                    if (matrix[beeRow, beeCol] =='f')
                    {

                        flowers++;

                    }
                }
                
                matrix[beeRow, beeCol] = 'B';
                command = Console.ReadLine();
            }
            if (flowers<5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }

            PrintMatrix(n, matrix);
        }
        private static bool isInside(int row, int col, int rows, int cols)
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

        private static void PrintMatrix(int n, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static int MoveRow(int row, string command)
        {
            if (command == "up")
            {
                return row - 1;
            }
            else if (command == "down")
            {
                return row + 1;
            }
            return row;
        }

        private static int MoveCol(int col, string command)
        {
            if (command == "left")
            {
                return col - 1;
            }
            else if (command == "right")
            {
                return col + 1;
            }
            return col;
        }
    }
}
