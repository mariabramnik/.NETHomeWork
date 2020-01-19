using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork37DelegatesCalculator
{
    class SimpleCalculator
    {
        public int NumberGetter()
        {
            int number = 0;
            bool success = false;
            while (!success || number <= 0)
            {
                Console.WriteLine("Please enter a number:");
                string num = Console.ReadLine();
                
                success = Int32.TryParse(num, out number);
            }
            Console.WriteLine(number);
            return number;
        }
        public void PrintMenu()
        {
            Console.WriteLine("To select  +  enter 1");
            Console.WriteLine("To select  -  enter 2");
            Console.WriteLine("To select  *  enter 3");
            Console.WriteLine("To select  /  enter 4");

        }
        public int GetUserChoise()
        {
            int number = 0;
            bool success = false;
            string num = Console.ReadLine();
            success = Int32.TryParse(num, out number);
            while (!success || number < 1 || number > 4)
            {
                PrintMenu();
                 num = Console.ReadLine();
                success = Int32.TryParse(num, out number);
            }
            return number;
        }
        public double Calculate(int x,int y,int z)
        {
            double res = 0;
            switch(z)
            {
                case 1: res = x + y;
                    break;
                case 2: res = x - y;
                    break;
                case 3: res = x * y;
                    break;
                case 4: res = x / y;
                    break;
            }
            return res;
        }
        public void PrintResultNicely(double res)
        {
            Console.WriteLine($"**** {res} ***");
        }
    }
}
