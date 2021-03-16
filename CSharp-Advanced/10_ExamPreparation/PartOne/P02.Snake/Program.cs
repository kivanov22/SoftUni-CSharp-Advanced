using System;

namespace P02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int snakeRow = 0;
            int snakeCol = 0;
            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }


            string command = Console.ReadLine();
            int snakeFood = 0;

            while (true)
            {
                matrix[snakeRow, snakeCol] = '.';
                snakeRow = MoveRow(snakeRow, command);
                snakeCol = MoveCol(snakeCol, command);


                if (!isValidPosition(snakeRow, snakeCol, n, n))
                {
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {snakeFood}");
                    break;
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    snakeFood++;
                }
                if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';

                    for (int rows = 0; rows < n; rows++)
                    {
                        for (int cols = 0; cols < n; cols++)
                        {
                            if (matrix[rows, cols] == 'B')
                            {
                                matrix[rows, cols] = 'S';
                                snakeRow = rows;
                                snakeCol = cols;
                            }
                        }
                    }
                }
                if (snakeFood >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    Console.WriteLine($"Food eaten: {snakeFood}");
                    matrix[snakeRow, snakeCol] = 'S';
                    break;
                }
                matrix[snakeRow, snakeCol] = 'S';
                command = Console.ReadLine();
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
        public static int MoveRow(int row, string commmand)
        {
            if (commmand == "up")
            {
                return row - 1;
            }
            else if (commmand == "down")
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
