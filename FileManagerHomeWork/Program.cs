using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace FileManagerHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ran = new Random();
            string str1 = "Once upon a time there was a gentleman who married, for his second wife," +
                " the proudest and most haughty woman that ever was seen. She had two daughters" +
                " of her own, who were, indeed, exactly like her in all things. The gentleman had also" +
                " a young daughter, of rare goodness and sweetness of temper, which she took from " +
                "her mother, who was the best creature in the world" +
                "The wedding was scarcely over, when the stepmother's " +
                 "bad temper began to show itself.She could not bear the goodness of this young girl," +
                 "because it made her own daughters appear the more odious.The stepmother gave her the meanest work" +
                "in the house to do; she had to scour the dishes, tables, etc., and to scrub the floors" +
               " and clean out the bedrooms. The poor girl had to sleep in the garret, upon a wretched " +
                "straw bed, while her sisters lay in fine rooms with inlaid floors, upon beds of the very" +
                "newest fashion, and where they had looking-glasses so large that they [Pg 2]might see " +
               " themselves at their full length. The poor girl bore all patiently, and dared not " +
               " complain to her father, who would have scolded her if she had done so, for his wife " +
               " governed him entirely.";
            string str2 = "When she had done her work, she used to go into the chimney corner, and sit " +
                "down among the cinders, hence she was called Cinderwench. The younger sister of the two," +
                " who was not so rude and uncivil as the elder, called her Cinderella. However, Cinderella, " +
                "in spite of her mean apparel, was a hundred times more handsome than her sisters, though " +
                "they were always richly dressed.";
            string str3 = "It happened that the King's son gave a ball, and invited to it all persons of fashion";
            string str4 = "the the Our young misses were also invited, for they cut a very grand figure among the people of the country-side.";
            string str5 = "They were highly delighted with the invitation,";
            WordFile wf1 = null;
            WordFile wf2 = null;
            WordFile wf3 = null;
            WordFile wf4 = null;
            WordFile wf5 = null;
            List<MyFile> filesList = new List<MyFile>();
            try
            {
                wf1 = new WordFile("C:\\test\\WileManagerEx1.txt", 500, true, true, str1);
                wf2 = new WordFile("C:\\test\\FileManagerEx2.txt", 200, false, false, str2);
                wf3 = new WordFile("C:\\test\\AileManagerEx3.txt", 300, false, false, str3);
                wf4 = new WordFile("C:\\test\\BileManagerEx4.txt", 100, true, true, str4);
 
            }
            catch(InfectedFileDetectedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (!(wf4 is null))
            {
                string text = wf4.Text;
                Console.WriteLine(text);
                int num = wf4.NumberOfWords(wf4.Text);
                int res = wf4.GetSpecificWordCount("the");
                Console.WriteLine($"the number of words in the text : {num}");
                Console.WriteLine($"this word appears in the text { res} times");
                string myStr = wf4[7];
                Console.WriteLine($"at this place in the text is the word: { myStr}");
                int numberOfPages = wf4.NumberOfPages;
                Console.WriteLine($"{ numberOfPages}  pages in this text");
                wf4.PrintFile();
            }
            filesList.Add(wf1);
            filesList.Add(wf2);
            filesList.Add(wf3);
            filesList.Add(wf4);
            FilePathCompare comparer = new FilePathCompare();
            filesList.Sort(comparer);
            foreach (MyFile mf in filesList)
            {
                Console.WriteLine(mf);
            }
            FileSizeCompare comparer1 = new FileSizeCompare();
            filesList.Sort(comparer1);
            foreach (MyFile mf in filesList)
            {
                Console.WriteLine(mf);
            }
            HelpFunctions hp1 = new HelpFunctions();
            int x1 = ran.Next(1, 20);
            int y1 = ran.Next(1, 20);
            HelpFunctions hp2 = new HelpFunctions();
            int x2 = ran.Next(1, 20);
            int y2 = ran.Next(1, 20);
            int[,] myMatrix1 = hp1.ReturnMatrixInt(x1, y1);
            char[,] myMatrix2 = hp2.ReturnMatrixChar('*',x2, y2);
            ImageFile<int> imfile1 = new ImageFile<int>("C:\\test\\FileManagerEx.txt6", 10, true, false, myMatrix1, x1, y1);
            ImageFile<char> imfile2 = new ImageFile<char>("C:\\test\\FileManagerEx.txt7", 10, true, false, myMatrix2, x2, y2);
            imfile1.PrintFile();
            imfile2.PrintFile();
            try
            {
                wf5 = new WordFile("C:\\test\\FileManagerEx5.txt", -1, true, true, str5);
            }
            catch (InfectedFileDetectedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            WordFile wf6 = wf3 + wf4;
            Console.WriteLine(wf6);
            Console.ReadLine();
        }
    }
}
