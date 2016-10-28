using System;

namespace SingletonExample
{
    class Startup
    {
        static void Main(string[] args)
        {
            Singleton SingletonObject = Singleton.GetObject();
            SingletonObject.Print("Telerik Academy");
        }
    }
}
