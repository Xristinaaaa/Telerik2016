﻿using DecoratorExample.BakeryComponents;

namespace DecoratorExample.DecoratorComponents
{
    class CherryDecorator : Decorator
    {
        public CherryDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.m_Name = "Cherry";
            this.m_Price = 2.0;
        }
    }
}
