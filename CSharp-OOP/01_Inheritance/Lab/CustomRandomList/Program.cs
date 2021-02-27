using System;

namespace CustomRandomList
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("Toshko");
            list.Add("Silva");
            list.Add("Gosho");
            list.Add("Makaron");
            list.Add("Peshko");
            list.Add("Shishko");

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(list.RandomString());
            }
        }
    }
}
