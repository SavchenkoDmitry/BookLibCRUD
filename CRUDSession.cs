using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryCRUD
{
    class CRUDSession
    {
        CRUDTextView tv;
        LibraryJsonCRUD crud;
        public CRUDSession(CRUDTextView _tv, LibraryJsonCRUD _crud)
        {
            tv = _tv;
            crud = _crud;
        }

        public void RunLoop()
        {
            while (true)
            {
                CRUDTextView.Action act = tv.AskAction();
                if (act == CRUDTextView.Action.Exit)
                {
                    break;
                }
                switch (act)
                {
                    case CRUDTextView.Action.Create:
                        CreateAction();
                        break;
                    case CRUDTextView.Action.Read:
                        ReadAction();
                        break;
                    case CRUDTextView.Action.Update:
                        UpdateAction();
                        break;
                    case CRUDTextView.Action.Delete:
                        DeleteAction();
                        break;
                }
            }
        }

        public void CreateAction()
        {
            string name = tv.AskBookName();
            string author = tv.AskBookAuthor();
            int pages = tv.AskBookPages();
            int count = tv.AskBookCount();
            int edition = tv.AskBookEdition();
            int id = tv.AskBookId();
            crud.AddBook(new Book() { name = name, author = author, pages = pages, count = count, edition = edition, id = id });
        }
        public void ReadAction()
        {
            int id = tv.AskBookId();
            try
            {
                tv.PrintBook(crud.GetBook(id));
            }
            catch (Exception e)
            {
                tv.PrintError(e.Message);
            }
        }
        public void UpdateAction()
        {
            int id = tv.AskBookId();
            try
            {
                tv.PrintBook(crud.GetBook(id));
            }
            catch (Exception e)
            {
                tv.PrintError(e.Message);
                return;
            }
            string name = tv.AskBookName();
            string author = tv.AskBookAuthor();
            int pages = tv.AskBookPages();
            int count = tv.AskBookCount();
            int edition = tv.AskBookEdition();
            crud.UpdateBook(id, name, author, pages, count, edition);
        }
        public void DeleteAction()
        {
            int id = tv.AskBookId();
            try
            {
                crud.DeleteBook(id);
            }
            catch (Exception e)
            {
                tv.PrintError(e.Message);
                return;
            }
            tv.PrintDeleted();
        }
    }
}
