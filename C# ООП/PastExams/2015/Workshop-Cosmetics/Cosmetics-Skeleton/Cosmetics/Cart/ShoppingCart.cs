namespace Cosmetics.Cart
{
    using Cosmetics.Contracts;
    using System;
    using System.Collections.Generic;

    public class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> productList;

        public ShoppingCart()
        {
            this.ProductList = null;
        }

        public ICollection<IProduct> ProductList
        {
            get
            {
                return new List<IProduct>(productList);
            }
            set
            {
                this.productList = value;
            }
        }

        public void AddProduct(IProduct product)
        {
            productList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            productList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            if (productList.Contains(product))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public decimal TotalPrice()
        {
            decimal totalPrice=0;
            foreach (var product in productList)
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }
    }
}
