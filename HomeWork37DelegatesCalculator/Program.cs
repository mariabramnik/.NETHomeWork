using System;

namespace HomeWork37DelegatesCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SimpleCalculator calc = new SimpleCalculator();
           // int num1 = calc.NumberGetter();
           // int num2 = calc.NumberGetter();
           // int oper = calc.GetUserChoise();
           // double res = calc.Calculate(num1,num2,oper);
           // calc.PrintResultNicely(res);
            AtomicCalculator atCalc = new AtomicCalculator();
            atCalc.GetNumberFromUser += calc.NumberGetter;
            atCalc.MenuPrinter += calc.PrintMenu;
            atCalc.GetUserChoice += calc.GetUserChoise;
            atCalc.Calculate += calc.Calculate;
            atCalc.ResultPrinter += calc.PrintResultNicely;
            atCalc.Run();


            Console.ReadLine();
        }
    }
}
