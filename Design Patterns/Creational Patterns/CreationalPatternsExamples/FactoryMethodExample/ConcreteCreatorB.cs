using FactoryMethodExample.Models;
using System;

namespace FactoryMethodExample
{
    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}
