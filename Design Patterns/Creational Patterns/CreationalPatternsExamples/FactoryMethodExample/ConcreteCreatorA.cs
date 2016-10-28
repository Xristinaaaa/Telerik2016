using FactoryMethodExample.Models;
using System;
namespace FactoryMethodExample
{
    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }
}
