using System.Collections;
using System.Collections.Generic;

namespace Lib
{
    public class LimitedList<T> : IEnumerable<T> where T : class
    {
        private T[] list;

        public int Capacity { get; }

        public LimitedList(int capacity)
        {
            Capacity = capacity;
            list = new T[capacity];
        }

        public bool Add(T element)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == null)
                {
                    list[i] = element;
                    return true;
                }
            }
            return false;
        }

        public bool Remove(T element)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == element)
                {
                    list[i] = null;
                    return true;
                }
            }
            return false;
        }

        public int Count()
        {
            int count = 0;

            foreach (var element in this) count++;

            // Without GetEnumerator()
            //for (int i = 0; i < list.Length; i++)
            //{
            //    if (list[i] != null)
            //    {
            //        count++;
            //    }
            //}
            return count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != null)
                {
                    yield return list[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class Test
    {
        void LimitedListTest()
        {

            var list = new LimitedList<string>(capacity: 3);
            int cap = list.Capacity; // 3
            bool firstAdd = list.Add("first");

            string second = "second";
            bool secondAdd = list.Add(second);

            int count = list.Count(); // 2

            foreach (var element in list)
            {
                var e = element;
            }

            bool removed = list.Remove(second);
            //bool removed2 = list.RemoveAt(1);
        }
    }
}
