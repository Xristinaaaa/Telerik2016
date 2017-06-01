using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands.Contracts
{
    public interface ICommandHandler
    {
        void AddCommandHandler(ICommandHandler loginHandler);

        string HandleCommand(ICommand command, IEngine engine);
    }
}
