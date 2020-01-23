using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerHomeWork
{
    class WordFile : MyFile , IWordCounter , ISpecificWordkCount
    {
        
        public string Text { get; set; }
        public Dictionary<string, int> wordDict = new Dictionary<string, int>();
        public WordFile(string filePath, int fileSize, bool readOnly, bool archiveFile, string text) : base(filePath, fileSize, readOnly, archiveFile)
        {
            this.Text = text;
        }
        public int NumberOfPages { get {
                string[] textArray = GetArrayWords(Text);
                int num = textArray.Length;
                int numberOfPages = num / 10;
                return numberOfPages;
            } }

        public override string ToString()
        {
            return$"File Path {filePath} , File Size {FileSize} ,ReadOnly : {ReadOnly} , Archived {ArchiveFile},Text : {Text} )";
        }

        public string this[int index]
        {
           get
              {
                string[] textArray = GetArrayWords(Text);
                return textArray[index - 1];

              }
         }

 
        public override void PrintFile()
        {
            string[]arr = GetArrayWords(Text);
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        public int NumberOfWords(string text)
        {
            string[] textArray = GetArrayWords(text);
            int num = textArray.Length;
            int count = 1;
            foreach(string word in textArray)
            {
                if (!wordDict.ContainsKey(word))
                {
                    wordDict.Add(word, count);
                }
                else
                {
                    int c = wordDict[word];
                    c = c + 1;
                    wordDict[word] = c;
                }

            }
            return num;
        }
        public int GetSpecificWordCount(string word)
        {
            int res = 0;
            if (wordDict.ContainsKey(word))
            {
               res = wordDict[word];
            }

            return res;
        }

        public string[] GetArrayWords(string text)
        {
            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }
            text = text.Trim(new char[] { ',', '.' });
            string[] textArray = text.Split(new char[] { ' ' });
            return textArray;
        }
        public override bool Equals(object obj)
        {
            bool res = false;
            WordFile mf2 = (WordFile)obj;
            if (mf2.Text == this.Text)
            {
                res = true;
            }
            return res;
        }
        public override int GetHashCode()
        {
            return this.Text.GetHashCode();
        }
        public static bool operator ==(WordFile f1, WordFile f2)
        {
            bool res = false;
            if (f1.Text == f2.Text)
            {
                res = true;
            }
            return res; ;
        }
        public static bool operator !=(WordFile f1, WordFile f2)
        {
            return !(f1 == f2);
        }
        public static WordFile operator +(WordFile f1, WordFile f2)
        {
            string newPath = "";
            int newFileSize = 0;
            string newText = "";
            FileSizeCompare comparer = new FileSizeCompare();
            int res = comparer.Compare(f1, f2);
            if (res == 1)
            {
                newPath = f1.FilePath;
            }
            else
            {
                newPath = f2.FilePath;
            }
            newPath += ".mrg";
            newFileSize = f1.FileSize + f2.FileSize;
            newText = f1.Text + " " + f2.Text;
            WordFile f3 = new WordFile(newPath, newFileSize, false, false, newText);
            return f3;
        }
    }
}
