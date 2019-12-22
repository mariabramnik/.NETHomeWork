using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork25GenericInimerable
{
    class Program
    {
        static void Main(string[] args)
        {
            Knight k1 = new Knight("Baskerwill", "BaskerwilHoll", "lord");
            Knight k2 = new Knight("Lanselot", "Arutown", "lord");
            Knight k3 = new Knight("Artur", "Camelot", "king");
            Knight k4 = new Knight("Gawain", "Berilac", "lord");
            Knight k5 = new Knight("Persivale", "ForestTown", "lord");
            Knight k6 = new Knight("Gareth", "Kitchen", "lord");
            Knight k7 = new Knight("Gelahad", "Corbenik", "lord");
            Knight k8 = new Knight("Tristan", "Loonua", "lord");
            Knight k9 = new Knight("Palomed", "GreenTown", "lord");
            RoundTable<Knight> rtKn = new RoundTable<Knight>();
            rtKn.Add(k1); rtKn.Add(k2); rtKn.Add(k3);
            rtKn.Add(k4); rtKn.Add(k5); rtKn.Add(k6); rtKn.Add(k7);
            rtKn.Add(k8);
            rtKn.PrintList();
            rtKn.Sort();
            rtKn.PrintList();
            rtKn.RemoveAt(3);
            rtKn.PrintList();
            rtKn.InsertAt(3, k9);
            rtKn.PrintList();
            rtKn.RemoveAt(33);
            rtKn.PrintList();
            rtKn.InsertAt(21, new Knight("Lionel","OldTown","lord"));
            rtKn.PrintList();
            Console.WriteLine("********************************************************");
            
            List<Knight> roundList = rtKn.GetRounded(33);
            foreach (Knight kn in roundList)
            {
                Console.WriteLine(kn.ToString());
            }
            Console.WriteLine($"RoundList = {roundList.Count} chairs");
            
            Console.ReadLine();
        }
       
    }
}
