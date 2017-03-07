using Dealership.Common;
using Dealership.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Engine.Handlers
{
    public class AddComment : CommandHandler
    {
        private const string CommandName = "AddComment";

        private readonly IDealershipFactory factory;

        public AddComment(IDealershipFactory factory)
        {
            this.factory = factory;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var content = command.Parameters[0];
            var author = command.Parameters[1];
            var vehicleIndex = int.Parse(command.Parameters[2]) - 1;

            var comment = this.factory.CreateComment(content);
            comment.Author = engine.LoggedUser.Username;
            var user = engine.Users.FirstOrDefault(u => u.Username == author);

            if (user == null)
            {
                return string.Format(Constants.NoSuchUser, author);
            }

            Validator.ValidateRange(vehicleIndex, 0, user.Vehicles.Count, Constants.VehicleDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];

            engine.LoggedUser.AddComment(comment, vehicle);

            return string.Format(Constants.CommentAddedSuccessfully, engine.LoggedUser.Username);
        }
    }
}
