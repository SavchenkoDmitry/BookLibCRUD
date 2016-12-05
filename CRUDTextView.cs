using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BookLibraryCRUD
{
    class CRUDTextView
    {
        public enum Action { Exit, Create, Read, Update, Delete };
        const int actions = 5;

        TextReader input;
        TextWriter output;
        public CRUDTextView(TextReader _input, TextWriter _output)
        {
            input = _input;
            output = _output;
        }

        public Action AskAction()
        {
            int result;
            while(true)
            {
                output.WriteLine("\nSelect acrion " + (int)Action.Exit + " - exit, " + (int)Action.Create + " - create, " + (int)Action.Read + " - read, " + (int)Action.Update + " - update, " + (int)Action.Delete + " - delete:");
                if (Int32.TryParse(input.ReadLine(), out result) && result >= 0 && result < actions)
                {
                    return (Action)result;
                }
                output.WriteLine("Wrong!");
            }
        }
        public string AskBookName()
        {
            output.Write("Book name : ");
            return input.ReadLine();
        }
        public string AskBookAuthor()
        {
            output.Write("Book author : ");
            return input.ReadLine();
        }
        public int AskBookPages()
        {
            int pages;
            while (true)
            {
                output.Write("Book pages : ");
                if (Int32.TryParse(input.ReadLine(), out pages) && pages > 0)
                {
                    return pages;
                }
                output.WriteLine("Wrong!");
            }
        }
        public int AskBookCount()
        {
            int count;
            while (true)
            {
                output.Write("Book count : ");
                if (Int32.TryParse(input.ReadLine(), out count) && count >= 0)
                {
                    return count;
                }
                output.WriteLine("Wrong!");
            }
        }
        public int AskBookEdition()
        {
            int edition;
            while (true)
            {
                output.Write("Book edition : ");
                if (Int32.TryParse(input.ReadLine(), out edition) && edition > 0)
                {
                    return edition;
                }
                output.WriteLine("Wrong!");
            }
        }
        public int AskBookId()
        {
            int id;
            while (true)
            {
                output.Write("Book id : ");
                if (Int32.TryParse(input.ReadLine(), out id) && id > 0)
                {
                    return id;
                }
                output.WriteLine("Wrong!");
            }
        }

        public void PrintBook(Book book)
        {
            output.WriteLine(book.id + ": " + book.name + "\n Author: " + book.author + "\n Pages: " + book.pages + "\n Count: " + book.count + "\n Edition: " + book.edition);
        }
        public void PrintError(string mesage)
        {
            output.WriteLine("Error: " + mesage);
        }
        public void PrintDeleted()
        {
            output.WriteLine("Deleted.");
        }

    }
}
