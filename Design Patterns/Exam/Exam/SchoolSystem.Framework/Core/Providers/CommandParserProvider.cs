using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Common;
using SchoolSystem.Framework.Factories.Contracts;

namespace SchoolSystem.Framework.Core.Providers
{
    public class CommandParserProvider : IParser
    {
        private ICommandFactory factory;
        public CommandParserProvider(ICommandFactory factory)
        {
            this.factory = factory;
        }
        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            var commandTypeInfo = this.FindCommand(commandName);
          
            var command = factory.CreateCommand(commandName);
            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
            {
                return null;
            }

            return commandParts;
        }

        private TypeInfo FindCommand(string commandName)
        {
            var currentAssembly = this.GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                .SingleOrDefault();

            if (commandTypeInfo == null)
            {
                throw new ArgumentException(Constants.NotFoundCommand);
            }

            return commandTypeInfo;
        }
    }
}
