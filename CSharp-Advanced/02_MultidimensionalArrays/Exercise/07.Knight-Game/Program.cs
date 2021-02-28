using System;

namespace _07.Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }


            int knightRow = 0;
            int knightCol = 0;
            int knightCount = 0;




            while (true)
            {
                int maxAttaaks = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int currentAttacks = 0;
                        if (matrix[row, col] == 'K')
                        {
                            if (isValid(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
                            {
                                currentAttacks++;
                            }
                            if (isValid(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
                            {
                                currentAttacks++;
                            }
                            if (isValid(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
                            {
                                currentAttacks++;
                            }
                            if (isValid(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
                            {
                                currentAttacks++;
                            }
                            if (isValid(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
                            {
                                currentAttacks++;
                            }
                            if (isValid(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
                            {
                                currentAttacks++;
                            }
                            if (isValid(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
                            {
                                currentAttacks++;
                            }
                            if (isValid(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
                            {
                                currentAttacks++;
                            }
                        }
                        if (currentAttacks > maxAttaaks)
                        {
                            maxAttaaks = currentAttacks;
                            knightCol = col;
                            knightRow = row;
                        }
                    }
                }
                if (maxAttaaks > 0)
                {
                    matrix[knightRow, knightCol] = '0';
                    knightCount++;
                }
                else
                {
                    Console.WriteLine(knightCount);
                    break;
                }

            }

        }
        private static bool isValid(char[,] matrix, int bombRow, int bombCol)
        {
            return bombRow >= 0 && bombRow < matrix.GetLength(0) && bombCol >= 0 && bombCol < matrix.GetLength(1);
        }
    }
}
