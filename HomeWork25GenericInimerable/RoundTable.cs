using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork25GenericInimerable
{
    class RoundTable<T> : IEnumerable<T> where T : IComparable
    {
        private List<T> entities;
        public RoundTable()
        {
            entities = new List<T>();
        }

        public void Add(T inst)
        {
            entities.Add(inst);
        }
        public void RemoveAt(int num)
        {
            int count = entities.Count();
                int ind = num % count;
                entities.RemoveAt(ind - 1);

        }
        public void Clear()
        {
            entities.Clear();
        }
        public void InsertAt(int num, T item)
        {
            List<T> list = new List<T>();
            int count = entities.Count();
            if (num <= count)
            {
                entities.Insert(num - 1, item);
            }
            else
            {
                list = GetRounded(num -1);
                list.Insert(num - 1, item);
                entities = list;

            }
        }
        public void Sort()
        {
            entities.Sort();
        }

        public List<T> GetRounded(int num)
        {
            List<T> myList = new List<T>();
            int count = entities.Count();
            if (num < count)
            {
                myList = entities.GetRange(0, num - 1);
            }
            else
            {
                int round = num / count;
                for (int i = 0; i < round; i++)
                {
                    myList.AddRange(entities);
                }
                int rest = num % count;
                myList.AddRange(entities.GetRange(0, rest));
            }
            return myList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return entities.GetEnumerator();
        }
        public void PrintList()
        {
            foreach (T inst in entities)
                Console.WriteLine(inst.ToString());
            Console.WriteLine("-------------------------------------------------------");
        }
        public T this[string str]
        {
            get
            {

                foreach (T inst in entities)
                {
                     if ((inst as Knight).Name == str)
                    {
                        return inst;
                    }
                }
                return default(T);
            }
        }
        public T this[int ind]
        {
            get
            {
              return entities[ind];
            }
            
        }
        public override string ToString()
        {
            string resStr = "";
            foreach (T inst in entities)
            {
                resStr += inst.ToString() + "/n";
            }
            return resStr;
        }
    }
}
