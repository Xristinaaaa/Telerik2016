using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Factories.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string input);

        ICommand GetCommand(string input);
    }
}
