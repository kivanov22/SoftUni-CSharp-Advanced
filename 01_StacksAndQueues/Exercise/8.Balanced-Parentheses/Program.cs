using System;
using System.Collections.Generic;

namespace _8.Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> open = new Stack<char>();

            string input = Console.ReadLine();
            bool isValid = true;//true untill its proven not
            foreach (char bracket in input)
            {

                if (bracket == '(' || bracket == '{' || bracket == '[')
                {
                    open.Push(bracket);
                    if (open.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                }

                else
                {
                    bool isFirstValid = bracket == ')' && open.Pop() == '(';//true
                    bool isSecondValid = bracket == '}' && open.Pop() == '{';
                    bool isThirdValid = bracket == ']' && open.Pop() == '[';

                    if (!isFirstValid && !isSecondValid && !isThirdValid)//if not valid then we set to false
                    {
                        isValid = false;
                        break;
                    }


                }
            }
            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
