using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryCRUD
{
    class BookRepository
    {
        private DataContext connector;
        public BookRepository(DataContext bjc)
        {
            connector = bjc;
        }

        public void AddBook(Book book)
        {
            Newtonsoft.Json.Linq.JArray books = connector.GetInfo();
            
            books.Add(Newtonsoft.Json.Linq.JToken.FromObject(book));
            connector.WriteInfo(books);
        }

        public Book GetBook(int id)
        {
            Newtonsoft.Json.Linq.JArray books = connector.GetInfo();
            Book book;
            book = books.Where(b=>b["id"].ToObject<int>().Equals(id)).First().ToObject<Book>();
            return book;
        }

        public void UpdateBook(int id, string name, string author, int pages, int count, int edition)
        {
            Newtonsoft.Json.Linq.JArray books = connector.GetInfo();
            Newtonsoft.Json.Linq.JToken jt = books.Where(b => b["id"].ToObject<int>().Equals(id)).First();
            jt["name"] = name;
            jt["author"] = author;
            jt["pages"] = pages;
            jt["count"] = count;
            jt["edition"] = edition;
            connector.WriteInfo(books);
        }
        public void DeleteBook(int id)
        {
            Newtonsoft.Json.Linq.JArray books = connector.GetInfo();
            Newtonsoft.Json.Linq.JToken jt = books.Where(b => b["id"].ToObject<int>().Equals(id)).First();
            books.Remove(jt);
            connector.WriteInfo(books);
        }
        
    }
}
