using System;

namespace P02.Re_Volt_Rework
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int countCommands = int.Parse(Console.ReadLine());
            int playerRow = 0;
            int playerCol = 0;




            for (int rows = 0; rows < size; rows++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int cols = 0; cols < size; cols++)
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

                if (command == "up")
                {
                    if (!IsInRange(size, playerRow, playerCol))
                    {
                        playerRow = size - 1;
                    }


                }
                else if (command == "down")
                {

                }
                else if (command == "left")
                {

                }
                else if (command == "right")
                {

                }
            }
        }
        public static bool IsInRange(int size, int playerRow, int playerCol)
        {
            return playerRow >= 0 && playerRow < size && playerCol >= 0 && playerCol < size;
        }
    }
}
