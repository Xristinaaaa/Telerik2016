using Dealership.Common;
using Dealership.Contracts;
using Dealership.Factories;
using Dealership.Engine.Handlers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dealership.Engine
{
    public sealed class DealershipEngine : IEngine
    {
        private IDealershipFactory factory;
        private readonly ICommandHandler commandHandler;
        private readonly IOProvider.IOProvider provider;

        private ICollection<IUser> users;
        private IUser loggedUser;
        private DealershipEngine(IDealershipFactory factory, ICommandHandler handler, IOProvider.IOProvider provider)
        {
            this.factory = factory;
            this.commandHandler = handler;
            this.provider = provider;

            this.users = new HashSet<IUser>();
            this.loggedUser = null;
        }
        public ICollection<IUser> Users
        {
            get
            {
                return this.users;
            }
        }

        public IUser LoggedUser
        {
            get
            {
                return this.loggedUser;
            }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        public void Reset()
        {
            this.factory = new DealershipFactory();
            this.users = new List<IUser>();
            this.loggedUser = null;
            var commands = new List<ICommand>();
            var commandResult = new List<string>();
            this.PrintReports(commandResult);
        }
        public void SetLoggedUser(IUser user)
        {
            this.loggedUser = user;
        }


        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = new Command(currentLine);
                commands.Add(currentCommand);

                currentLine = Console.ReadLine();
            }

            return commands;
        }

        private IList<string> ProcessCommands(IList<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            this.provider.WriteLine(output.ToString());
        }

        private string ProcessSingleCommand(ICommand command)
        {
            if (command.Name != "RegisterUser" && command.Name != "Login")
            {
                if (this.loggedUser == null)
                {
                    return Constants.UserNotLogged;
                }
            }

            return this.commandHandler.HandleCommand(command, this);
        }
    }
}
