using System;

namespace SingletonExample
{
    public class Singleton
    {
        protected static Singleton obj;
        private Singleton()
        {

        }
        public static Singleton GetObject()
        {
            if (obj == null)
            {
                obj = new Singleton();
            }
            return obj;
        }
        public void Print(string s)
        {
            Console.WriteLine(s);
        }
    }
}
