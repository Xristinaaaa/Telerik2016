namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using System.Linq;

    public class Category : ICategory
    {
        private const int CategoryMinLength = 2;
        private const int CategoryMaxLength = 15;
        private string name;
        private ICollection<IProduct> productList;

        public Category(string name)
        {
            this.Name = name;
            productList=new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfStringLengthIsValid(
                    value,
                    CategoryMaxLength,
                    CategoryMinLength,
                    String.Format(GlobalErrorMessages.InvalidStringLength,
                    this.GetType().Name + " name", CategoryMinLength, CategoryMaxLength));
                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            productList.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            foreach (var item in productList)
            {
                if (!productList.Contains(item))
                {
                    Console.WriteLine("Product {0} does not exist in category {1}!", item.Name, this.Name);
                }
                productList.Remove(item);
            }
        }

        public string Print()
        {
            StringBuilder result=new StringBuilder();
            result.AppendLine(String.Format("{0} category – {1} {2} in total",
                this.Name, productList.Count,
                productList.Count==1? "product": "products"));

            var sortedProducts = this.productList.OrderBy(x => x.Brand).ThenByDescending(x => x.Price);

            foreach (var product in sortedProducts)
            {
                result.AppendLine(product.Print());
            }
            return result.ToString().Trim();
        }
    }
}
