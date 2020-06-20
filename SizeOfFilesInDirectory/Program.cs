using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SizeOfFilesInDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your directory:");
            string dirName = Console.ReadLine();
            DirectoryInfo di = new DirectoryInfo(dirName);
            try
            {           
                if (!di.Exists)
                {                
                    Console.WriteLine("That path doesn't exist.");
                    return;
                }
                long FilesSize = DirectoryTreeFilesSize(di);
                Console.WriteLine("All files size in directory: {0} = {1} bytes", dirName, FilesSize);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }

            Console.ReadLine();
        }

        static long DirectoryTreeFilesSize(System.IO.DirectoryInfo root)
        {
            long res = 0;
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    Console.WriteLine(fi.FullName);
                    res += fi.Length;
                }
            }

            subDirs = root.GetDirectories();
            if (subDirs != null)
            {
                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                  
                    res += DirectoryTreeFilesSize(dirInfo);
                }
            }

            return res;
        }
    }
}
