using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerHomeWork
{
    interface IFileAttributes
    {
         int FileSize { get;  set; }
         bool ReadOnly { get; set; }
         bool ArchiveFile { get;  set; }
         bool InfectedFile { get; set; }
    }
}
