using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerHomeWork
{
    public abstract class MyFile : IFileAttributes
    {
        static public List<string> filePathList = new List<string>();
        protected readonly string filePath;
        const bool hebLanguage = true;
        public int FileSize { get; set; }
        public bool ReadOnly { get; set; }
        public bool ArchiveFile { get; set; }
        public bool InfectedFile { get; set; }

        public MyFile(string filePath, int fileSize, bool readOnly, bool archiveFile)
        {
            this.filePath = filePath;
            FileSize = fileSize;
            ReadOnly = readOnly;
            ArchiveFile = archiveFile;
            filePathList.Add(filePath);
           InfectedFile = VirusScanner.IsFileInfected(fileSize,filePath);
            
        }
        public string FilePath { get { return filePath; } }
        public abstract void PrintFile();
        public override bool Equals(object obj)
        {
            bool res = false;
            MyFile mf2 = (MyFile)obj;
            if (mf2.FilePath == this.FilePath)
            {
                res = true;
            }
            return res;
        }
        public override int GetHashCode()
        {
            return this.filePath.GetHashCode();
        }
        public static bool operator ==(MyFile f1, MyFile f2)
        {
            bool res = false;
            if(f1.filePath == f2.filePath)
            {
                res = true;
            }
            return res; ;
        }
        public static bool operator !=(MyFile f1, MyFile f2)
         {
            return !(f1 == f2);
         }
       // public abstract static bool operator +(MyFile f1, MyFile f2);
 




    }
}
