using Dealership.Common;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class MotorCycle : Vehicle, IMotorcycle
    {
        private string category;

        public MotorCycle(string make, string model, decimal price, int wheelsCount)
            : base(make, model, price, 2)
        {

        }

        public MotorCycle(string make, string model, decimal price, string category)
            : this(make, model, price, 2)
        {
            this.Category = category;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            protected set
            {
                Validator.ValidateNull(value, "Category cannot be null!");
                Validator.ValidateIntRange(value.Length, Constants.MinCategoryLength, Constants.MaxCategoryLength,
                    Constants.StringMustBeBetweenMinAndMax);
                this.category = value;
            }
        }

        public override string ToString()
        {
            return this.Category.ToString();
        }
    }
}
