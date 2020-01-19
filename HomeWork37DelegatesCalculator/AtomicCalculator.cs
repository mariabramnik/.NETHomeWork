using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork37DelegatesCalculator
{
    class AtomicCalculator
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Func<int> GetNumberFromUser { get; set; }
        public Action MenuPrinter { get; set; }
        public Func<int> GetUserChoice { get; set; }
        public Func<int, int, int, double> Calculate { get; set; }
        public Action<double>ResultPrinter{ get; set; }
        public void Run()
        {
            X = GetNumberFromUser.Invoke();
            Y = GetNumberFromUser.Invoke();
            MenuPrinter.Invoke();
            int oper = GetUserChoice.Invoke();
            double res = Calculate.Invoke(X, Y, oper);
            ResultPrinter.Invoke(res);
              
        }
    }
}
