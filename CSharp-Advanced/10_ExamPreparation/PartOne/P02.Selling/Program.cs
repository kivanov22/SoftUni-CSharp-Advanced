using System;

namespace P02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];


            int row = 0;
            int col = 0;
            int sumMoney = 0;

            for (int rows = 0; rows < n; rows++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = rowData[cols];

                    
                    if (matrix[rows, cols] == 'S')
                    {
                        row = rows;
                        col = cols;
                    }
                }
            }

           
            
            while (true)
            { 
                string command = Console.ReadLine();

                if (command=="up")
                {
                    matrix[row, col] = '-';
                    row = row - 1; 
                    if (row >= 0) 
                    {
                        PlayerMove(n, matrix, ref row, ref col, ref sumMoney);
                    }
                    else 
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {sumMoney}");
                        break;
                    }
                }
                else if (command == "down")
                {
                    matrix[row, col] = '-'; 
                    row = row + 1; 
                    if (row < n) 
                    {
                        PlayerMove(n, matrix, ref row, ref col, ref sumMoney);
                    }
                    else 
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {sumMoney}");
                        break;
                    }
                }
                else if (command == "left")
                {
                    matrix[row, col] = '-'; 
                    col = col - 1; 
                    if (col >= 0) 
                    {
                        PlayerMove(n, matrix, ref row, ref col, ref sumMoney);
                    }
                    else 
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {sumMoney}");
                        break;
                    }
                }
                else if (command == "right")
                {
                    matrix[row, col] = '-'; 
                    col = col + 1; 
                    if (col < n) 
                    {
                        PlayerMove(n, matrix, ref row, ref col, ref sumMoney);
                    }
                    else 
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {sumMoney}");
                        break;
                    }
                }
                if (sumMoney>=50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    Console.WriteLine($"Money: {sumMoney}");
                    matrix[row, col] = 'S';
                    break;
                }

               
            }
            PrintMatrix(n, matrix);
        }

        private static void PlayerMove(int n, char[,] matrix, ref int row, ref int col, ref int sumMoney)
        {
            if (char.IsDigit(matrix[row,col]))
            {
                sumMoney += int.Parse(matrix[row,col].ToString());
            }
            else if (matrix[row, col] == 'O') 
            {
                matrix[row, col] = '-';
                for (int rows = 0; rows < n; rows++)
                {
                    for (int cols = 0; cols < n; cols++)
                    {
                        if (matrix[rows, cols] == 'O')
                        {
                            matrix[rows, cols] = 'O';
                            row = rows;
                            col = cols;
                        }
                    }
                }
            }
        }

        public static void PrintMatrix(int n, char[,] matrix)
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
