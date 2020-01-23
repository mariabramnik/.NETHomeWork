using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerHomeWork
{
    class FileSizeCompare : IComparer<MyFile>
    {
        public int Compare(MyFile mf1, MyFile mf2)
        {
            if(mf1.FileSize > mf2.FileSize)
            {
                return 1;
            }
            if(mf1.FileSize == mf2.FileSize)
            {
                return 0;
            }
            return -1;
        }
    }
}
