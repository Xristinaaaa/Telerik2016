namespace WebServer.Application
{
    using ConsoleWebServer.Framework.Controllers;

    public static class Startup
    {
        public static void Main()
        {
            var webSever = new WebServerConsole5();
            webSever.Start();
        }
    }
}
