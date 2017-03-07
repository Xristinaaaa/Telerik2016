using Dealership.Common;
using System.Linq;
namespace Dealership.Engine.Handlers
{
    public class RemoveCommentHandler : CommandHandler
    {
        private const string CommandName = "RemoveComment";
        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;
            var commentIndex = int.Parse(command.Parameters[1]) - 1;
            var username = command.Parameters[2];

            var user = engine.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return string.Format(Constants.NoSuchUser, username);
            }

            Validator.ValidateRange(vehicleIndex, 0, user.Vehicles.Count, Constants.RemovedVehicleDoesNotExist);
            Validator.ValidateRange(commentIndex, 0, user.Vehicles[vehicleIndex].Comments.Count, Constants.RemovedCommentDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];
            var comment = user.Vehicles[vehicleIndex].Comments[commentIndex];

            engine.LoggedUser.RemoveComment(comment, vehicle);

            return string.Format(Constants.CommentRemovedSuccessfully, engine.LoggedUser.Username);
        }
    }
}
