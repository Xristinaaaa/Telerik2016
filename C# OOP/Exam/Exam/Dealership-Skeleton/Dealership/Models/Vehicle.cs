using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;
using Dealership.Common;
using System.Globalization;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle, ICommentable
    {
        private string make;
        private string model;
        private decimal price;
        private int wheelsCount;
        private ICollection<IComment> comments;

        public Vehicle(string make, string model, decimal price, int wheelsCount)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Wheels = wheelsCount;
            this.comments = new List<IComment>();
        }

        public IList<IComment> Comments
        {
            get
            {
                return new List<IComment>(comments);
            }
            private set
            {
                if (this.comments==null)
                {
                   String.Format(Constants.CommentCannotBeNull);
                }
            }
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            protected set
            {
                Validator.ValidateNull(value, "Make cannot be null!");
                Validator.ValidateIntRange(value.Length, Constants.MinMakeLength, Constants.MaxMakeLength, 
                    Constants.StringMustBeBetweenMinAndMax);
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            protected set
            {
                Validator.ValidateNull(value, "Model cannot be null!");
                Validator.ValidateIntRange(value.Length, Constants.MinModelLength, Constants.MaxModelLength, 
                    Constants.StringMustBeBetweenMinAndMax);
                this.model = value;
            }
        }
        
        public decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                Validator.ValidateNull(value, "Price cannot be null!");
                Validator.ValidateDecimalRange(value, Constants.MinPrice, Constants.MaxPrice, 
                    Constants.NumberMustBeBetweenMinAndMax);
                this.price = value;
            }
        }

        public VehicleType Type { get; }

        public int Wheels
        {
            get
            {
                return this.wheelsCount;
            }
            protected set
            {
                Validator.ValidateNull(value, "Wheels count cannot be null!");
                Validator.ValidateIntRange(value, Constants.MinWheels, Constants.MaxWheels, 
                    Constants.NumberMustBeBetweenMinAndMax);
                this.wheelsCount = value;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{{0}}:", this.Type).AppendLine();
            builder.AppendFormat("Make: {0}", this.Make).AppendLine();
            builder.AppendFormat("Model: {0}", this.Model).AppendLine();
            builder.AppendFormat("Wheels: {0}", this.Wheels).AppendLine();
            builder.AppendFormat("Price: ${0}", this.Price).AppendLine();
            builder.AppendFormat("Category/Weight capacity/Seats: {0}", base.ToString()).AppendLine();
            return builder.ToString();
        }
    }
}
