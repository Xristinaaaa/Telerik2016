namespace Cosmetics.Products
{
    using System;
    using Cosmetics.Contracts;
    using Cosmetics.Common;
    using System.Text;

    public abstract class Product : IProduct
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private decimal price;
        private string name;
        private string brand;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.CheckIfStringLengthIsValid(
                    value,
                    NameMaxLength,
                    NameMinLength,
                    String.Format(GlobalErrorMessages.InvalidStringLength,
                    this.GetType().Name + "Product name", NameMinLength, NameMaxLength));
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            protected set
            {
                Validator.CheckIfStringLengthIsValid(
                    value,
                    BrandMaxLength,
                    BrandMinLength,
                    String.Format(GlobalErrorMessages.InvalidStringLength,
                    this.GetType().Name + "Product brand", BrandMinLength, BrandMaxLength));
                this.brand = value;
            }
        }

        public virtual decimal Price { get;}

        public GenderType Gender { get; }

        public virtual string Print()
        {
            var result = new StringBuilder();
            result.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            result.Append(string.Format("  * Price: ${0}\n  * For gender: {1}", this.Price, this.Gender.ToString()));

            return result.ToString().TrimEnd();
        }
    }
}
