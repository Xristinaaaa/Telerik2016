using DecoratorExample.BakeryComponents;

namespace DecoratorExample.DecoratorComponents
{
    class CreamDecorator : Decorator
    {
        public CreamDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.m_Name = "Cream";
            this.m_Price = 1.0;
        }
    }
}
