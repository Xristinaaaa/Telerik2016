using AdapterExample.Contract;
using AdapterExample.Models;
using System;
namespace AdapterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ITarget adapter = new VendorAdapter();

            foreach (string product in adapter.GetProducts())
            {
                Console.WriteLine(product);
            }
        }
    }
}
