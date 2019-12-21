using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkDictionary24
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book("bfgdhsg", "content1", "abthor", "category1");
            Book b2 = new Book("hjgkfn", "content2", "bithor", "category2");
            Book b3 = new Book("aarhvdb", "content3", "cuthor", "category3");
            Book b4 = new Book("vndfbdh", "content4", "duthor", "category4");
            Book b5 = new Book("aassddff", "content5", "wbthor", "category5");
            Book b6 = new Book("aassddffe", "content6", "futhor", "category6");
            Book b7 = new Book("fhdhsb", "content7", "author", "category7");
            Book b8 = new Book("ccvgjg", "content8", "buthor", "category8");
            Book b9 = new Book("mhkfjsg", "content9", "wbthor", "category9");
            Book b10 = new Book("adfghgqq", "content10", "wathor", "category10");
            MyLibrary ml = new MyLibrary();
            ml.AddBook(b1); ml.AddBook(b8);
            ml.AddBook(b2); ml.AddBook(b9);
            ml.AddBook(b3); ml.AddBook(b10);
            ml.AddBook(b4);
            ml.AddBook(b5);
            ml.AddBook(b6);
            ml.AddBook(b7);
            List<string> list = ml.GetAuthors();
            foreach(string str in list)
            {
                Console.WriteLine(str);
            }
            Dictionary<string,Book> dict = ml.GetBookByAuthor("sbthor");
            if (dict != null)
            {
                foreach (var b in dict)
                {
                    Book book = b.Value;
                    Console.WriteLine(b.Key + " " + book.ToString());
                }
            }
            else
            {
                Console.WriteLine("no books by such an author");
            }
            Book myBook =  ml.GetBook("name1");
            if (myBook != null)
            {
                Console.WriteLine(myBook.ToString());
            }
            else
            {
                Console.WriteLine("not found book with that title");
            }
            List<Book> myListByAuthor = ml.GetBooksSortedByAuthorName();
            foreach(Book b in myListByAuthor)
            {
                Console.WriteLine(b.ToString());
            }
            List<string> myListByTitle = ml.GetBooksTitleSorted();
            foreach (string str in myListByTitle)
            {
                Console.WriteLine(str);
            }

            Console.ReadLine();
        }
    }
}
