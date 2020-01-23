using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerHomeWork
{
    
    class HelpFunctions
    {
        public static Random rand = new Random();
        public int[,] arrInt;
        public char[,] arrChar;
        public int x;
        public int y;
        public int[,] ReturnMatrixInt(int x,int y)
        {
            arrInt = new int[x,y];
            for(int i = 0; i < x; i++)
            {              
                for (int j = 0; j < y; j++ )
                {
                    arrInt[i,j] = rand.Next(1, 20);
                }              
            }
            return arrInt;
        }
        public char[,] ReturnMatrixChar(char c,int x, int y)
        { 
            arrChar = new char[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    arrChar[i, j] = c;
                }
            }
            return arrChar;
        }
    }
}
