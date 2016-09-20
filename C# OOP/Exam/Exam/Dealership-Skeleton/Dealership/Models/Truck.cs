using Dealership.Common;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Truck : Vehicle, ITruck
    {
        private int weightCapacity;
        
        public Truck(string make, string model, decimal price)
            : base(make, model, price, 8)
        {

        }

        public Truck(string make, string model, decimal price, int weightCapacity)
             : base(make, model, price, 8)
        {
            this.WeightCapacity = weightCapacity;
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }
            protected set
            {
                Validator.ValidateNull(value, "Weight capacity cannot be null!");
                Validator.ValidateIntRange(value, Constants.MinCapacity, Constants.MaxCapacity, 
                    Constants.NumberMustBeBetweenMinAndMax);
                this.weightCapacity = value;
            }
        }

        public override string ToString()
        {
            return this.WeightCapacity.ToString();
        }
    }
}
