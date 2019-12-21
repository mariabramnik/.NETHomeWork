using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkDictionary24
{
    class MyLibrary
    {
        private Dictionary<string, Book> books; 
        public MyLibrary()
        {
            books = new Dictionary<string, Book>();
        }
        public int Count
        {
            get
            {
                return books.Count();
            }
        }

        public bool AddBook(Book book)
        {
            bool res = false;
            string keyBook = book.Title;
            bool exist = HaveThisBook(keyBook);
            if(exist)
            {
                Console.WriteLine("this book already exists, it cannot be added again.");
            }
            else
            {
                books.Add(keyBook, book);
                res = true;
            }
            return res;
        }
        public bool RemoveBook(string keyBook)
        {
            bool res = false;
            bool exist = HaveThisBook(keyBook);
            if (exist)
            {
                Console.WriteLine("Are you sure you want to delete this book?" +
                    "If yes, then press Y; if not, then press N.");
                string answer = Console.ReadLine();
                if (answer == "Y")
                {
                    books.Remove(keyBook);
                    Console.WriteLine("book deleted.");
                    res = true;
                }
                
            }
            return res;
        }
        public bool HaveThisBook(string bookTitle)
        {
            bool res = false;
            if(books.ContainsKey(bookTitle))
            {
                res = true;
            }
            return res;
        }
        public Book GetBook(string bookTitle)
        {
            Book myBook = null;
            if (books.ContainsKey(bookTitle))
            {
                myBook = books[bookTitle];
            }
            return myBook;
        }

        public Dictionary<string, Book> GetBookByAuthor(string author)
        {
            Dictionary<string, Book> dictRes = new Dictionary<string, Book>();
            Dictionary<string, Book> dict = books.OrderBy(pair => pair.Value.Author).
                ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach(var v in dict)
            {
                if(v.Value.Author == author)
                {
                    dictRes.Add(v.Key,v.Value);
                }
            }
            if (dictRes == null || dictRes.Count == 0)
            {
                dictRes = null;
            }
            return dictRes;

        }

        public void Clear()
        {
            books.Clear();
        }
        public List<string>GetAuthors()
        {
            List<string> list = new List<string>();
            foreach (var b in books)
            {
                string str = b.Value.Author;
                list.Add(str);
                
            }
            list.Sort();
            return list;
        }
        public List<Book>GetBooksSortedByAuthorName()
        {
            Dictionary<string, Book> dict = books.OrderBy(pair => pair.Value.Author).
            ToDictionary(pair => pair.Key, pair => pair.Value);
            List<Book> list = new List<Book>();
            foreach(var v in dict)
            {
                list.Add(v.Value);
            }
            return list;
        }
        public List<string> GetBooksTitleSorted()
        {
            Dictionary<string, Book> dict = books.OrderBy(pair => pair.Value.Title).
            ToDictionary(pair => pair.Key, pair => pair.Value);
            List<string> list = new List<string>();
            foreach (var v in dict)
            {
                list.Add(v.Value.Title);
            }
            return list;
        }
        public override string ToString()
        {
            String resStr = "";
            foreach(var b in books)
            {
                resStr += (b.ToString() + " ");
            }
            return resStr;
        }

    }
}
