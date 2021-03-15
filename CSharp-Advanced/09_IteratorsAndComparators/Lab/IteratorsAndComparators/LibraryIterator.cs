using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int currentIndex;

        public LibraryIterator(IEnumerable<Book> books)
        {
            Reset();
            this.books = new List<Book>(books);
        }

        public Book Current => books[currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
           
        }

        public bool MoveNext()
        {
            currentIndex++;

            return currentIndex < books.Count;//means there is a current index we can move
        }

        public void Reset()
        {
            currentIndex = -1;//setting to default
        }
    }
}