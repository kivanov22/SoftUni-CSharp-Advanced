using System;
using System.Linq;

namespace _06.Jagged_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] jagged = new int[n, n];


            for (int row = 0; row < n; row++)
            {
                string[] data = Console.ReadLine().Split();
                

                for (int col = 0; col < data.Length; col++)
                {
                    jagged[row,col] = int.Parse(data[col]);
                }
            }


            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] cmdArgs = command.Split();
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (row >= 0 && col >= 0 && row < n && col < n)//validation check if index out of range
                {
                    if (cmdArgs[0] == "Add")
                    {
                        jagged[row,col] += value;
                    }
                    if (cmdArgs[0] == "Subtract")
                    {
                        jagged[row,col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }


                command = Console.ReadLine();
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(jagged[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
