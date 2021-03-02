using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];

            char[,] field = new char[n, m];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < m; col++)
                {
                    field[row, col] = rowData[col];

                    if (field[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            //1.Take input and fill the matrix
            //2.Check what index is player
            //3.Check what index is bunny
            //4.for loop for going through directions
            //5.making validations
            char[] directions = Console.ReadLine().ToCharArray();
            bool isWon = false;
            bool isDead = false;
            foreach (char direction in directions)
            {
                int newPlayerRow = playerRow;//save position of player
                int newPlayerCol = playerCol;//potential position and current position

                if (direction == 'U')
                {
                    newPlayerRow--;
                }
                else if (direction == 'D')
                {
                    newPlayerRow++;
                }
                else if (direction == 'L')
                {
                    newPlayerCol--;
                }
                else if (direction == 'R')
                {
                    newPlayerCol++;
                }

                if (!isValidCell(newPlayerRow, newPlayerCol, n, m))
                {
                    isWon = true;
                    field[playerRow, playerCol] = '.';
                    List<int[]> bunniesCoordinates = GetBunniesCoordinates(field);
                    SpreadBunnies(bunniesCoordinates, field);
                }
                else if (field[newPlayerRow, newPlayerCol] == '.')
                {
                    field[playerRow, playerCol] = '.';
                    field[newPlayerRow, newPlayerCol] = 'P';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;

                    List<int[]> bunniesCoordinates = GetBunniesCoordinates(field);
                    SpreadBunnies(bunniesCoordinates, field);

                    if (field[playerRow, playerCol] == 'B')
                    {
                        isDead = true;
                    }
                }
                else if (field[newPlayerRow, newPlayerCol] == 'B')
                {
                    isDead = true;
                    field[playerRow, playerCol] = '.';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;

                    List<int[]> bunniesCoordinates = GetBunniesCoordinates(field);
                    SpreadBunnies(bunniesCoordinates, field);
                }



                if (isDead || isWon)
                {
                    break;
                }
            }
            PrintField(field);
            string res = "";

            if (isWon)
            {
                res += "won";
            }
            else
            {
                res += "dead";
            }
            res += $": {playerRow} {playerCol}";
            Console.WriteLine(res);
        }

        private static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void SpreadBunnies(List<int[]> bunniesCoordinates, char[,] field)
        {
            int rowsLength = field.GetLength(0);
            int colsLength = field.GetLength(1);

            foreach (int[] bunnyCoordinate in bunniesCoordinates)
            {
                int row = bunnyCoordinate[0];
                int col = bunnyCoordinate[1];

                SpreadBunny(row - 1, col, field);
                SpreadBunny(row + 1, col, field);
                SpreadBunny(row, col - 1, field);
                SpreadBunny(row, col + 1, field);


            }
        }

        private static void SpreadBunny(int row, int col, char[,] field)
        {
            int rowsLength = field.GetLength(0);
            int colsLength = field.GetLength(1);

            if (isValidCell(row , col, rowsLength, colsLength))
            {
                field[row , col] = 'B';
            }
        }

        private static List<int[]> GetBunniesCoordinates(char[,] field)
        {
            List<int[]> bunniesCoordinates = new List<int[]>();

            for (int row = 0; row < field.GetLength(0); row++)
            {

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    

                    if (field[row, col] == 'B')
                    {
                        bunniesCoordinates.Add(new int[] { row, col });
                    }
                }
            }
            return bunniesCoordinates;
        }

        private static bool isValidCell(int row, int col, int n, int m)//validation method
        {
            return row >= 0 && row < n && col >= 0 && col < m;
        }
    }
}
