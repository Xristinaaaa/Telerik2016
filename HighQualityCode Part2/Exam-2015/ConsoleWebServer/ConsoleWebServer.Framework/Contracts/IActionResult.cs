namespace ConsoleWebServer.Framework.Contracts
{
    using HttpSettings;

    public interface IActionResult
    {
        HttpResponse GetResponse();
    }
}