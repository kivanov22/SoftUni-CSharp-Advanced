using System;

namespace P02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int countCommands = int.Parse(Console.ReadLine());
            int playerRow = 0;
            int playerCol = 0;
            bool isWiner = false;



            for (int rows = 0; rows < n; rows++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = rowData[cols];

                    if (matrix[rows, cols] == 'f')
                    {
                        playerRow = rows;
                        playerCol = cols;
                    }
                }
            }


            
            

           

            for (int i = 0; i < countCommands; i++)
            {
                string command = Console.ReadLine();
                matrix[playerRow, playerCol] = '-';
                playerRow = MoveRow(playerRow, command);
                playerCol = MoveCol(playerCol, command);



                if (isWiner==true)
                {

                    break;
                }

                if (!isValidPosition(playerRow, playerCol, n, n))
                {

                    switch (command)
                    {
                        case "up":
                            playerRow = n - 1;
                            break;
                        case "down":
                            playerRow = 0;
                            break;
                        case "left":
                            playerCol = n - 1;
                            break;
                        case "right":
                            playerCol = 0;
                            break;
                    }
                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        isWiner = true;
                        break;
                    }
                    matrix[playerRow, playerCol] = 'f';

                }
                if (matrix[playerRow, playerCol] == 'B')
                {
                    // matrix[playerRow, playerCol] = 'f';
                    playerRow = MoveRow(playerRow, command);
                    playerCol = MoveCol(playerCol, command);

                    if (!isValidPosition(playerRow, playerCol, n, n))
                    {

                        switch (command)
                        {
                            case "up":
                                playerRow = n - 1;
                                break;
                            case "down":
                                playerRow = 0;
                                break;
                            case "left":
                                playerCol = n - 1;
                                break;
                            case "right":
                                playerCol = 0;
                                break;
                        }
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            isWiner = true;
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

                        switch (command)
                        {
                            case "up":
                                playerRow = n - 1;
                                break;
                            case "down":
                                playerRow = 0;
                                break;
                            case "left":
                                playerCol = n - 1;
                                break;
                            case "right":
                                playerCol = 0;
                                break;
                        }
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            isWiner = true;
                            break;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                    //if (matrix[playerRow, playerCol] == 'F')
                    //{
                    //    matrix[playerRow, playerCol] = 'f';
                    //    isWiner = true;
                    //    break;
                    //}
                }
                if (matrix[playerRow, playerCol] == 'F')
                {
                    isWiner = true;
                    matrix[playerRow, playerCol] = 'f';
                    
                    break;
                    
                }
                matrix[playerRow, playerCol] = 'f';
                    //command = Console.ReadLine();
                }
            if (isWiner)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
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

        }
    }

