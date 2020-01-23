using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerHomeWork
{
    public class FilePathCompare : IComparer<MyFile>
    {
        public int Compare(MyFile x, MyFile y)
        {
            return x.FilePath.CompareTo(y.FilePath);
         }
    }
}
