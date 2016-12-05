using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryCRUD
{
    class Program
    {
        static void Main()
        {
            DataContext bjc = new DataContext();
            List<Book> books = InitBooks();
            bjc.WriteInfo(books);
            BookRepository lib = new BookRepository(bjc);
            CRUDTextView tv = new CRUDTextView(System.Console.In, System.Console.Out);
            CRUDSession session = new CRUDSession(tv, lib);
            session.RunLoop();
        }

        static List<Book> InitBooks()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book() { name = "BookA", author = "AuthorA", count = 3, edition = 2, id = 1, pages = 225 });
            books.Add(new Book() { name = "BookB", author = "AuthorA", count = 2, edition = 1, id = 2, pages = 125 });
            return books;
        }
    }
}
