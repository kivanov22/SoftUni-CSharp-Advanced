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


            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row,col]=='B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string command = Console.ReadLine();
            int flowers = 0;
            while (command!="End")
            {
                matrix[beeRow, beeCol] = '.';
                beeRow = MoveRow(beeRow, command);
                beeCol = MoveCol(beeCol, command);

                if (!isValidPosition(beeRow, beeCol, n, n))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                if (matrix[beeRow,beeCol]=='f')
                {
                    flowers++;
                }
                if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow = MoveRow(beeRow, command);
                    beeCol = MoveCol(beeCol, command);

                    if (!isValidPosition(beeRow, beeCol, n, n))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                    if (matrix[beeRow, beeCol] == 'f')
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

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        public static bool isValidPosition(int row, int col,int rows,int cols)
        {
            if (row<0 ||row >=rows)
            {
                return false;
            }
            if (col<0 ||col >= cols)
            {
                return false;
            }
            return true;
        }
        public static int MoveRow(int row, string commmand)
        {
            if (commmand=="up")
            {
                return row - 1;
            }
            else if (commmand=="down")
            {
                return row + 1;
            }
            return row;
        }
        public static int MoveCol(int col, string commmand)
        {
            if (commmand == "left")
            {
                return col - 1;
            }
            else if (commmand == "right")
            {
                return col + 1;
            }
            return col;
        }

    }
}
