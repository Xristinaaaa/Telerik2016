﻿using System.Windows;

namespace Surfaces
{
    public class PropertyHolder<PropertyType, HoldingType> where HoldingType:DependencyObject
    {
        DependencyProperty property;

        public PropertyHolder(string name, PropertyType defaultValue, PropertyChangedCallback propertyChangedCallback)
        {
            property = DependencyProperty.Register(
                    name, 
                    typeof(PropertyType), 
                    typeof(HoldingType), 
                    new PropertyMetadata(defaultValue, propertyChangedCallback));
        }

        public DependencyProperty Property
        {
            get
            {
                return this.property;
            }
        }

        public PropertyType Get(HoldingType obj)
        {
            return (PropertyType)obj.GetValue(property);
        }

        public void Set(HoldingType obj, PropertyType value)
        {
            obj.SetValue(property, value);
        }
    }
}
