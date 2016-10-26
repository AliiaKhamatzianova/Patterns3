
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    public sealed class Singleton
    {
        private static Lazy<Singleton> _instance = new Lazy<Singleton>(()=>new Singleton());//null;// new Singleton();

        static Singleton()
        {
            Console.WriteLine("Singleton created");
        }

        //private static object _locker = new object();

        public static Singleton Instance => _instance.Value;
        
        //public static Singleton GetInstance()
        //{
        //    if (_instance == null)
        //    {
        //        //lock (_locker)
        //        //{
        //           // if (_instance == null)
        //               // _instance = new Singleton();
        //        //}
        //    }

        //    return _instance.Value;
        //}
    }

    public class Fibonacci : IEnumerable<int>
    {
        private class FibonacciIterator : IEnumerator<int>
        {
            private int cur = 1;
            private int prev = 0;
            private int counter = 0;

            public int Current
            {
                get
                {
                    if (counter < 2)
                        return counter;
                    else
                        return cur;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose() { }
           

            public bool MoveNext()
            {
                if (cur +prev <= 0) return false;

                cur = cur + prev;
                prev = cur - prev;
                counter++;
                return true;
            }

            public void Reset()
            {
                counter = 0;
                cur = 1;
                prev = 0;
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new FibonacciIterator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton s;
            //s = Singleton.GetInstance();
            s = Singleton.Instance;

        }
    }
}
