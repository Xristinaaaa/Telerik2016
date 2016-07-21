using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;
using Dealership.Common;
using Dealership.Engine;

namespace Dealership.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string password;
        private string role;
        private string username;
        private ICollection<IVehicle> vehicles;

        public User(string firstName, string lastName, string password, string username)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Username = username;
            this.vehicles = new List<IVehicle>();
        }

        public User(string firstName, string lastName, string password, string username, string role) 
            : this(firstName, lastName, password, username)
        {
            this.role = role;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                Validator.ValidateNull(value, "Name cannot be null!");
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength, 
                    Constants.StringMustBeBetweenMinAndMax);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                Validator.ValidateNull(value, "Name cannot be null!");
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength,
                    Constants.StringMustBeBetweenMinAndMax);
                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            protected set
            {
                Validator.ValidateNull(value, "Password cannot be null!");
                Validator.ValidateIntRange(value.Length, Constants.MinPasswordLength, Constants.MaxPasswordLength, 
                    Constants.StringMustBeBetweenMinAndMax);
                Validator.ValidateSymbols(value, Constants.PasswordPattern, 
                    Constants.InvalidSymbols);
                this.password = value;
            }
        }

        public Role Role { get; }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                Validator.ValidateNull(value, Constants.UserCannotBeNull);
                Validator.ValidateSymbols(value, Constants.UsernamePattern, 
                    Constants.InvalidSymbols);
                this.username = value;
            }
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return new List<IVehicle>(vehicles);
            }
            protected set
            {
                if (this.vehicles == null)
                {
                    String.Format(Constants.VehicleCannotBeNull);
                }
            }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            //vehicleToRemoveComment.Add(commentToRemove);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            bool canAdd=true;

            if (this.Role==Role.Admin)
            {
                canAdd = false;
                String.Format(Constants.AdminCannotAddVehicles);
            }
            if (this.Role==Role.VIP && this.vehicles.Count==5)
            {
                canAdd = false;
                String.Format(Constants.NotAnVipUserVehiclesAdd);
            }

            if (canAdd)
            {
                this.vehicles.Add(vehicle);
            }
        }

        public string PrintVehicles()
        {
            var result = new StringBuilder();
            result.AppendFormat("--USER { {0}}--", this.Username).AppendLine();

            foreach (var vehicle in vehicles)
            {
                result.Append(vehicle.ToString());

                result.Append("  --COMMENTS--").AppendLine();
                result.Append("  ----------").AppendLine();
                //result.Append(vehicle.Comment.ToString()).AppendLine();
                result.AppendFormat("User: {0}", this.Username).AppendLine();
                result.Append("  ----------").AppendLine();
                result.Append("  --COMMENTS--");
            }
            return result.ToString();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            //vehicleToRemoveComment.Remove(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.vehicles.Remove(vehicle);
        }

        public override string ToString()
        {
           return string.Format(Constants.UserToString, this.Username, this.FirstName, this.lastName) 
                +string.Format(", Role: {0}",this.Role);
        }
    }
}
