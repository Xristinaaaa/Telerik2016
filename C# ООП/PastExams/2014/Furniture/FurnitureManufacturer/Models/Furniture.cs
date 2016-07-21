namespace FurnitureManufacturer.Models
{
    using Interfaces;
    using System;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;

        public virtual decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be less or equal to 0");
                }
                this.height = value;
            }
        }

        public virtual string Model
        {
            get
            {
                return this.model;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Model cannot be empty or null");
                    
                }

                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Model cannot be with less than 3 symbols");
                }

                this.model = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be less or equal to 0");
                }
                this.price = value;
            }
        }


        public virtual string Material
        {
            get
            {
                return this.MaterialType.ToString();
            }
        }
        protected MaterialType MaterialType { get; set; }
        
    }
}
