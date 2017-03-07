using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Factories;
using System;
using System.Linq;

namespace Dealership.Engine.Handlers
{
    public class RegisterUserHandler : CommandHandler
    {
        private const string CommandName = "RegisterUser";

        private readonly IDealershipFactory factory;
        public RegisterUserHandler(IDealershipFactory factory)
        {
            this.factory = factory;
        }
        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var username = command.Parameters[0];
            var firstName = command.Parameters[1];
            var lastName = command.Parameters[2];
            var password = command.Parameters[3];

            if (engine.LoggedUser != null)
            {
                return string.Format(Constants.UserLoggedInAlready, engine.LoggedUser.Username);
            }

            if (engine.Users.Any(u => u.Username.ToLower() == username.ToLower()))
            {
                return string.Format(Constants.UserAlreadyExist, username);
            }

            var user = this.factory.CreateUser(username, firstName, lastName, password, Role.Normal.ToString());
            engine.SetLoggedUser(user);
            engine.Users.Add(user);

            return string.Format(Constants.UserRegisterеd, username);
        }
    }
}
