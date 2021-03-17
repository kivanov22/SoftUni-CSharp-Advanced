using System;

namespace P02.Revolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int playerRow = 0;
            int playerCol = 0;
            int countCommand = int.Parse(Console.ReadLine());
            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }


            bool isWinner = false;
            for (int i = 0; i < countCommand; i++)
            {
                string command = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';
                playerRow = MoveRow(playerRow, command);
                playerCol = MoveCol(playerCol, command);
                if (isWinner == true)
                {

                    break;
                }

                if (!isValidPosition(playerRow, playerCol, n, n))
                {
                    playerRow = NewPositionRow(playerRow, n, n);
                    playerCol = NewPositionCol(playerCol, n, n);
                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        isWinner = true;
                        break;
                    }
                    matrix[playerRow, playerCol] = 'f';

                }
                if (matrix[playerRow, playerCol] == 'B')
                {

                    playerRow = MoveRow(playerRow, command);
                    playerCol = MoveCol(playerCol, command);

                    if (!isValidPosition(playerRow, playerCol, n, n))
                    {
                        playerRow = NewPositionRow(playerRow, n, n);
                        playerCol = NewPositionCol(playerCol, n, n);


                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            isWinner = true;
                            break;
                        }
                        matrix[playerRow, playerCol] = 'f';

                    }
                }
                if (matrix[playerRow, playerCol] == 'T')
                {
                    // matrix[playerRow, playerCol] = 'f';
                    playerRow = BackWardRow(playerRow, command);
                    playerCol = BackWardCol(playerCol, command);

                    if (!isValidPosition(playerRow, playerCol, n, n))
                    {
                        playerRow = NewPositionRow(playerRow, n, n);
                        playerCol = NewPositionCol(playerCol, n, n);

                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            isWinner = true;
                            break;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }

                }
                if (matrix[playerRow, playerCol] == 'F')
                {
                    isWinner = true;
                    matrix[playerRow, playerCol] = 'f';

                    break;

                }
                matrix[playerRow, playerCol] = 'f';
            }
            if (isWinner)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(n, matrix);


        }
        public static int MoveRow(int row, string command)
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
        public static int MoveCol(int col, string command)
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

        public static int BackWardRow(int row, string command)
        {
            if (command == "up")
            {
                return row + 1;
            }
            else if (command == "down")
            {
                return row - 1;
            }

            return row;
        }
        public static int BackWardCol(int col, string command)
        {

            if (command == "left")
            {
                return col + 1;
            }
            else if (command == "right")
            {
                return col - 1;
            }
            return col;
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

        public static int NewPositionRow(int row, int rows, int n)//To Do with string
        {
            if (row < 0)
            {
                row = n - 1;
            }
            if (row >= rows)
            {
                row = 0;
            }
            return row;

        }
        public static int NewPositionCol(int col, int cols, int n)
        {
            if (col < 0)
            {
                col = n - 1;
            }
            if (col >= cols)
            {
                col = 0;
            }
            return col;
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
    }
}
