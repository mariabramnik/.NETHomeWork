using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerHomeWork
{
    interface IWordCounter
    {
        int NumberOfWords(string text);
        string this[int index]
        {
            get;
        }
        int NumberOfPages { get; }

    }
}
