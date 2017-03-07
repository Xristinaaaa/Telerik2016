using Dealership.Common;
using Dealership.Factories;
using System.Linq;

namespace Dealership.Engine.Handlers
{
    public class ShowVehicles : CommandHandler
    {
        private const string CommandName = "ShowUserVehicle";
        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var username = command.Parameters[0];
            var user = engine.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (user == null)
            {
                return string.Format(Constants.NoSuchUser, username);
            }

            return user.PrintVehicles();
        }
    }
}
