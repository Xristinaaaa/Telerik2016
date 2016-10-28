namespace ConsoleWebServer.Framework.Actions
{
    using ConsoleWebServer.Framework.Contracts;
    using ConsoleWebServer.Framework.Controllers;

    internal class NewActionInvoker
    {
        public IActionResult InvokeAction(Controller controller, ActionDescriptor actionDescriptor)
        {
            return new ActionInvoker().InvokeAction(controller, actionDescriptor);
        }
    }
}
