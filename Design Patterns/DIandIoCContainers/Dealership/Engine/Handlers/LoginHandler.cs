using Dealership.Common;
using Dealership.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Engine.Handlers
{
    public class LoginHandler : CommandHandler
    {
        private const string CommandName = "Login";

        private readonly IDealershipFactory factory;
        public LoginHandler(IDealershipFactory factory)
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
            var password = command.Parameters[1];

            if (engine.LoggedUser != null)
            {
                return string.Format(Constants.UserLoggedInAlready, engine.LoggedUser.Username);
            }

            var userFound = engine.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (userFound != null && userFound.Password == password)
            {
                engine.SetLoggedUser(userFound);
                return string.Format(Constants.UserLoggedIn, username);
            }

            return Constants.WrongUsernameOrPassword;
        }
    }
}
