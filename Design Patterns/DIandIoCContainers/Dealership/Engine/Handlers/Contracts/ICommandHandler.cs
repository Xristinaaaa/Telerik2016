namespace Dealership.Engine.Handlers.Contracts
{
    public interface ICommandHandler
    {
        void AddCommandHandler(ICommandHandler loginHandler);

        string HandleCommand(ICommand command, IEngine engine);
    }
}
