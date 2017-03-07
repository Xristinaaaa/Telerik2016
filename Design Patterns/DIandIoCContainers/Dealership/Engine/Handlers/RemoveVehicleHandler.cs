using Dealership.Common;
using System;

namespace Dealership.Engine.Handlers
{
    public class RemoveVehicleHandler : CommandHandler
    {
        private const string CommandName = "RemoveVehicle";
        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;

            Validator.ValidateRange(vehicleIndex, 0, engine.LoggedUser.Vehicles.Count, Constants.RemovedVehicleDoesNotExist);

            var vehicle = engine.LoggedUser.Vehicles[vehicleIndex];

            engine.LoggedUser.RemoveVehicle(vehicle);

            return string.Format(Constants.VehicleRemovedSuccessfully, engine.LoggedUser.Username);
        }
    }
}
