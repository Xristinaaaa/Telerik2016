namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using Cosmetics.Contracts;
    using Cosmetics.Common;
    using System.Linq;

    public class Toothpaste : Product, IToothpaste, IProduct
    {
        private const int IngredientMinLength = 4;
        private const int IngredientMaxLength = 12;

        private decimal price;
        private IEnumerable<string> ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IEnumerable<string> ingredients)
            :base(name, brand, price, gender)
        {
            ingredients = new List<string>(ingredients);
        }

        public string Ingredients
        {
            get
            {
                return String.Join(", ", ingredients);             
            }
            protected set
            {
                if (this.ingredients.Any(i => i.Length < IngredientMinLength || i.Length>IngredientMaxLength))
                {
                    throw new IndexOutOfRangeException(string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", IngredientMinLength, IngredientMaxLength));
                }
            }
        }

        public override decimal Price
        {
            get
            {
                return this.price;
            }
        }

        public override string Print()
        {
            return base.Print() 
                   + string.Format("\n  * Ingredients: {0}", this.Ingredients);
        }
    }
}
