namespace ConsoleWebServer.Framework.JsonActionResults
{
    using System.Collections.Generic;
    using ConsoleWebServer.Framework.HttpSettings;

    public class JsonActionResultWithCorsWithoutCaching : JsonActionResult
    {
        private const string CacheControl = "Cache-Control";
        private const string Keys = "private, max-age=0, no-cache";

        public JsonActionResultWithCorsWithoutCaching(HttpRq request, object model, string corsSettings) : base(request, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
            this.ResponseHeaders.Add(new KeyValuePair<string, string>(CacheControl, Keys));
        }
    }
}
