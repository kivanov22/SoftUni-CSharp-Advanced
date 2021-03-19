using System;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            string[] coordinates = Console.ReadLine()
                .Split(",");
            char[,] matrix = new char[n, n];


            int countFirstPlayerShips = 0;
            int countSecondPlayerShips = 0;

            for (int row = 0; row < n; row++)
            {
                
                char[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == '<')
                    {
                        countFirstPlayerShips++;
                    }
                    if (matrix[row, col] == '>')
                    {
                        countSecondPlayerShips++;
                    }
                }
            }

            int firstCountShips = countFirstPlayerShips;
            int secondCountShips = countSecondPlayerShips;
            for (int i = 0; i < coordinates.Length; i++)
            {
                if (countFirstPlayerShips <= 0 || countSecondPlayerShips <= 0)
                {
                    break;
                }
                string[] coordinate = coordinates[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
               

                int row = int.Parse(coordinate[0]);
                int col = int.Parse(coordinate[1]);

                if (!IsValidPosition(row, col, n))
                {
                    continue;
                }

                if (i % 2 == 0)
                {
                    if (matrix[row, col] == '>')
                    {
                        matrix[row, col] = 'X';
                        countSecondPlayerShips--;
                    }

                    if (matrix[row, col] == '#')
                    {
                        matrix = Mine(ref countFirstPlayerShips, ref countSecondPlayerShips, row, col, matrix, n);
                    }
                }
                if (i % 2 != 0)
                {
                    if (matrix[row, col] == '<')
                    {
                        matrix[row, col] = 'X';
                        countFirstPlayerShips--;
                    }

                    if (matrix[row, col] == '#')
                    {
                        matrix = Mine(ref countFirstPlayerShips, ref countSecondPlayerShips, row, col, matrix, n);
                    }
                }
            }
            if (countFirstPlayerShips <= 0 || countSecondPlayerShips <= 0)
            {
                if (countFirstPlayerShips > 0)
                {
                    int destroyShips = secondCountShips + (firstCountShips - countFirstPlayerShips);
                    Console.WriteLine($"Player One has won the game! {destroyShips} ships have been sunk in the battle.");
                }
                else
                {
                    int destroyShips = firstCountShips + (secondCountShips - countSecondPlayerShips);
                    Console.WriteLine($"Player Two has won the game! {destroyShips} ships have been sunk in the battle.");
                }
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {countFirstPlayerShips} ships left. Player Two has {countSecondPlayerShips} ships left.");
            }

        }
        static char[,] Mine(ref int countFistPlayerShip, ref int countSecondPlayerShips, int row, int col, char[,] matrix, int n)
        {
            int coordinateRow;
            int coordinateCol;

            if (IsValidPosition(row - 1, col, n))
            {
                coordinateRow = row - 1;
                IsThereShip(ref countFistPlayerShip, ref countSecondPlayerShips, matrix[coordinateRow, col]);
                matrix[coordinateRow, col] = 'X';
            }

            if (IsValidPosition(row + 1, col, n))
            {
                coordinateRow = row + 1;
                IsThereShip(ref countFistPlayerShip, ref countSecondPlayerShips, matrix[coordinateRow, col]);
                matrix[coordinateRow, col] = 'X';
            }

            if (IsValidPosition(row, col + 1, n))
            {
                coordinateCol = col + 1;
                IsThereShip(ref countFistPlayerShip, ref countSecondPlayerShips, matrix[row, coordinateCol]);
                matrix[row, coordinateCol] = 'X';
            }

            if (IsValidPosition(row, col - 1, n))
            {
                coordinateCol = col - 1;
                IsThereShip(ref countFistPlayerShip, ref countSecondPlayerShips, matrix[row, coordinateCol]);
                matrix[row, coordinateCol] = 'X';
            }

            if (IsValidPosition(row - 1, col - 1, n))
            {
                coordinateRow = row - 1;
                coordinateCol = col - 1;
                IsThereShip(ref countFistPlayerShip, ref countSecondPlayerShips, matrix[coordinateRow, coordinateCol]);
                matrix[coordinateRow, coordinateCol] = 'X';
            }

            if (IsValidPosition(row - 1, col + 1, n))
            {
                coordinateRow = row - 1;
                coordinateCol = col + 1;
                IsThereShip(ref countFistPlayerShip, ref countSecondPlayerShips, matrix[coordinateRow, coordinateCol]);
                matrix[coordinateRow, coordinateCol] = 'X';
            }

            if (IsValidPosition(row + 1, col - 1, n))
            {
                coordinateRow = row + 1;
                coordinateCol = col - 1;
                IsThereShip(ref countFistPlayerShip, ref countSecondPlayerShips, matrix[coordinateRow, coordinateCol]);
                matrix[coordinateRow, coordinateCol] = 'X';
            }

            if (IsValidPosition(row + 1, col + 1, n))
            {
                coordinateRow = row + 1;
                coordinateCol = col + 1;
                IsThereShip(ref countFistPlayerShip, ref countSecondPlayerShips, matrix[coordinateRow, coordinateCol]);
                matrix[coordinateRow, coordinateCol] = 'X';
            }
            matrix[row, col] = 'X';

            return matrix;
        }
        static void IsThereShip(ref int firstShips, ref int secondShips, char character)
        {
            if (character == '<')
            {
                firstShips--;
            }

            if (character == '>')
            {
                secondShips--;
            }
        }


        static bool IsValidPosition(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}


