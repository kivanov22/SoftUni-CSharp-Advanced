using System;

namespace P02.Seiling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int snakeRows = 0;
            int snakeCols = 0;


            for (int rows = 0; rows < n; rows++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = rowData[cols];

                    if (matrix[rows, cols] == 'S')
                    {
                        snakeRows = rows;
                        snakeCols = cols;
                    }
                }
            }


            string command = Console.ReadLine();
            int money = 0;

            while (true)
            {
                matrix[snakeRows, snakeCols] = '-';
                snakeRows = MoveRow(snakeRows, command);
                snakeCols = MoveCol(snakeCols, command);

                if (!isInside(snakeRows, snakeCols, n, n))
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }
                if (money >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    matrix[snakeRows, snakeCols] = 'S';
                    break;
                }
                if (char.IsDigit(matrix[snakeRows, snakeCols]))
                {
                    
                    money += int.Parse(matrix[snakeRows, snakeCols].ToString());
                    matrix[snakeRows, snakeCols] = '-';
                    if (money >= 50)
                    {
                        Console.WriteLine("Good news! You succeeded in collecting enough money!");
                        matrix[snakeRows, snakeCols] = 'S';
                        break;
                    }

                }
                if (matrix[snakeRows, snakeCols] == 'O')
                {
                    matrix[snakeRows, snakeCols] = '-';
                    snakeRows = MoveRow(snakeRows, command);//TODO
                    snakeCols = MoveCol(snakeCols, command);
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row, col] == 'O')
                            {
                                //matrix[snakeRows, snakeCols] = 'O';
                                snakeRows = row;
                                snakeCols = col;

                            }
                        }
                    }
                }
                matrix[snakeRows, snakeCols] = 'S';
                command = Console.ReadLine();
            }
            Console.WriteLine($"Money: {money}");

            PrintMatrix(n, matrix);
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

        private static int MoveCol(int col, string commmand)
        {
            if (commmand == "left")
            {
                return col  -1;
            }
            else if (commmand == "right")
            {
                return col  +1;
            }
            return col;
        }

        private static int MoveRow(int row, string command)
        {
            if (command == "up")
            {
                return row  -1;
            }
            else if (command == "down")
            {
                return row  +1;
            }
            return row;
        }

    }
}
