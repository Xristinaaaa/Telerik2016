using Dealership.Common;
using Dealership.Factories;
using System;

namespace Dealership.Engine.Handlers
{
    public class LogoutHandler : CommandHandler
    {
        private const string CommandName = "Logout";

        private readonly IDealershipFactory factory;
        public LogoutHandler(IDealershipFactory factory)
        {
            this.factory = factory;
        }
        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            engine.SetLoggedUser(null);
            return Constants.UserLoggedOut;
        }
    }
}