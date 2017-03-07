using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Factories;
using System;
using System.Text;

namespace Dealership.Engine.Handlers
{
    public class ShowAllUsersHandler : CommandHandler
    {
        private const string CommandName = "ShowAllUsers";
        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            if (engine.LoggedUser.Role != Role.Admin)
            {
                return Constants.YouAreNotAnAdmin;
            }

            var builder = new StringBuilder();
            builder.AppendLine("--USERS--");
            var counter = 1;

            foreach (var user in engine.Users)
            {
                builder.AppendLine(string.Format("{0}. {1}", counter, user.ToString()));
                counter++;
            }

            return builder.ToString().Trim();
        }
    }
}
