namespace Cosmetics.Products
{
    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using System;
    using System.Text;

    public class Shampoo : Product, IShampoo, IProduct
    {
        private decimal price;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            :base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
         }

        public uint Milliliters { get; set; }

        public UsageType Usage { get; set; }

        public override decimal Price
        {
            get
            {
                return this.price * this.Milliliters;
            }
        }

        public override string Print()
        {
            return base.Print()
                   + string.Format("\n  * Quantity: {0} ml\n  * Usage: {1}",
                   this.Milliliters, this.Usage.ToString());
        }
    }
}
