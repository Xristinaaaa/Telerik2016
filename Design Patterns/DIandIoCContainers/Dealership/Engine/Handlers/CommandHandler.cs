using Dealership.Engine;
using Dealership.Engine.Handlers.Contracts;
using Dealership.Common;

namespace Dealership.Engine.Handlers
{
    public abstract class CommandHandler : ICommandHandler
    {
        private ICommandHandler nextHandler;

        public void AddCommandHandler(ICommandHandler nextHandler)
        {
            this.nextHandler = nextHandler;
        }

        public string HandleCommand(ICommand command, IEngine engine)
        {
            string result;
            if (this.CanHandle(command))
            {
                result = this.Handle(command, engine);
            }
            else if (this.nextHandler != null)
            {
                result = this.nextHandler.HandleCommand(command, engine);
            }
            else
            {
                result = string.Format(Constants.InvalidCommand, command.Name);
            }

            return result;
        }
        protected abstract bool CanHandle(ICommand command);

        protected abstract string Handle(ICommand command, IEngine engine);
    }
}
