namespace ConsoleWebServer.Framework.Contracts
{
    using ConsoleWebServer.Framework.HttpSettings;

    public interface IResponseProvider
    {
        HttpResponse GetResponse(string requestAsString);
    }
}