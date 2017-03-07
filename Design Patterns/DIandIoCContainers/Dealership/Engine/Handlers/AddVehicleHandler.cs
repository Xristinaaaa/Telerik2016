using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Factories;
using System;

namespace Dealership.Engine.Handlers
{
    public class AddVehicleHandler : CommandHandler
    {
        private const string CommandName = "AddVehicle";

        private readonly IDealershipFactory factory;

        public AddVehicleHandler(IDealershipFactory factory)
        {
            this.factory = factory;
        }
        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            IVehicle vehicle = null;

            var type = command.Parameters[0];
            var make = command.Parameters[1];
            var model = command.Parameters[2];
            var price = decimal.Parse(command.Parameters[3]);
            var additionalParam = command.Parameters[4];

            var typeConverted = (VehicleType)Enum.Parse(typeof(VehicleType), type, true);

            if (typeConverted == VehicleType.Car)
            {
                vehicle = this.factory.CreateCar(make, model, price, int.Parse(additionalParam));
            }
            else if (typeConverted == VehicleType.Motorcycle)
            {
                vehicle = this.factory.CreateMotorcycle(make, model, price, additionalParam);
            }
            else if (typeConverted == VehicleType.Truck)
            {
                vehicle = this.factory.CreateTruck(make, model, price, int.Parse(additionalParam));
            }

            engine.LoggedUser.AddVehicle(vehicle);

            return string.Format(Constants.VehicleAddedSuccessfully, engine.LoggedUser.Username);
        }
    }
}
