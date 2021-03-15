using System;

namespace IteratorsAndComparators
{
   public class Program
    {
        static void Main(string[] args)
        {
            Book[] books = new Book[]
            {
                new Book("something",1995,"Kris"),
                new Book("check",1986,"Gosho")
            };
            Library myLibrary = new Library(books);

            
            foreach (var item in myLibrary)
            {
                Console.WriteLine(item);
            }


        }
    }
}
