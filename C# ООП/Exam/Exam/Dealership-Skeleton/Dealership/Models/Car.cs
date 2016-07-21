using Dealership.Common;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{ 
    public class Car : Vehicle, ICar
    {
        private int seats;

        public Car(string make, string model, decimal price) 
            : base(make, model, price, 4)
        {

        }
        public Car(string make, string model, decimal price, int seats)
             : base(make, model, price, 4)
        {
            this.Seats = seats;
        }


        public int Seats
        {
            get
            {
                return this.seats;
            }
            protected set
            {
                Validator.ValidateIntRange(value, Constants.MinSeats, Constants.MaxSeats, 
                    Constants.NumberMustBeBetweenMinAndMax);
                Validator.ValidateNull(value, "Seats count cannot be null!");
                this.seats = value;
            }
        }

        public override string ToString()
        {
            return this.Seats.ToString();
        }
    }
}
