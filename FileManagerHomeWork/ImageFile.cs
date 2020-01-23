using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerHomeWork
{
    class ImageFile<T> : MyFile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public T[,] myMatrix;
        public ImageFile(string filePath, int fileSize, bool readOnly, bool archiveFile, T[,] MyMatrix, int x, int y) : base(filePath, fileSize, readOnly, archiveFile)
        {
            X = x;
            Y = y;
            myMatrix = MyMatrix;
        }
 
        public override void PrintFile()
        {
            for(int i = 0; i < X; i++ )
            {
                for(int j = 0; j < Y; j++ )
                {
                    Console.Write($"{myMatrix[i, j]}  ");
                }
                Console.WriteLine();
            }
            
        }
    }
}
