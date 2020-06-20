using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQ1
{
    class Program
    {
        static Dictionary<string, int> dict = new Dictionary<string, int>();
        static string[] arr;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your formula:");
            string formula = Console.ReadLine();
            Console.WriteLine("Enter your sentence:");
            string sentence = Console.ReadLine();
            bool isFormulaCorrectly = ValidationOfInputFormula(formula);
            bool isSentenceCorrectly = ValidationOfSentence(sentence);
            if (isFormulaCorrectly == false)
            {
                Console.WriteLine("Your formula entered incorrectly");
            }
            if(isSentenceCorrectly == false)
            {
                Console.WriteLine("Your sentence entered incorrectly");
            }
            else
            {
                ParseFormula(formula,sentence);
            }
            Console.ReadLine();

        }
        static bool ValidationOfInputFormula(string formula)
        {
            bool res = true;
            char[] arr = formula.ToCharArray();
            int len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                bool ischar = Char.IsLetter(arr[i]);
                if (ischar == false && arr[i] != ',' && arr[i] != '@')
                {

                    res = false;
                    break;
                }
            }
            return res;
        }
        static bool ValidationOfSentence(string sentence)
        {
            bool res = true;
            char[] arr = sentence.ToCharArray();
            int len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                bool ischar = Char.IsLetter(arr[i]);
                if (ischar == false)
                {

                    res = false;
                    break;
                }
            }
            return res;
        }

        static void ParseFormula(string formula, string sentence)
        {
            bool contains = false;
           int count = 0;
            arr = formula.Split('@');
            string res = "";
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i].Replace(",", "");
            }
            GetComb(res, 0);
            foreach(KeyValuePair<string,int> paar in dict)
            {
                count++;
                Console.WriteLine($"{paar.Key} {count}");
            }
            /*if(sentence.Length ==  dict.ElementAt(1).Key.Length)
            {
                char[] arrCharSentence = sentence.ToCharArray();
                foreach (KeyValuePair<string, int> paar in dict)
                {
                    char[] arrCharKey = paar.Key.ToCharArray();
                    for(int i = 0; i < sentence.Length; i++)
                    {
                        contains = arrCharKey.Contains(sentence[i]);
                        if(contains == false)
                        {
                            Console.WriteLine("this sentence does not match the formula");
                            break;
                            
                        }
                    }
                    
                }
                Console.WriteLine("this sentence corresponds to the formula");
            }
            else
            {
                Console.WriteLine("this sentence does not match the formula in length");
            }
            */
            sentence = String.Concat(sentence.OrderBy(c => c));
            int value;
            bool hasValue = dict.TryGetValue(sentence, out value);
            if (hasValue && value == 1)
            {
                Console.WriteLine($"{sentence} - this sentence corresponds to the formula");
            }
            else
            {
                Console.WriteLine($"{sentence} this sentence does not match the formula");
            }
        }

        static void GetComb(string res, int ind)
        {
            if (arr.Length > ind)
            {
                char[] letters = arr[ind].ToCharArray();
                foreach (char letter in letters)
                {
                    GetComb(res + letter, ind + 1);
                }
            }
            else
            {
                res = String.Concat(res.OrderBy(c => c));
                dict.Add(res, 1);
            }
           
        }
    }
}
