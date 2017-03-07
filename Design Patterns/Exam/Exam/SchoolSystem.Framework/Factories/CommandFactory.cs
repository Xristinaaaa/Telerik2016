using SchoolSystem.Framework.Factories.Contracts;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private IParser parser;
        public CommandFactory(IParser parser)
        {
            this.parser = parser;
        }
        public ICommand CreateCommand(string input)
        {
            return new Command(input);
        }

        public ICommand GetCommand(string input)
        {
            return parser.ParseCommand(input);
        }
    }
}
