namespace ConsoleWebServer.Framework.JsonActionResults
{
    using System;
    using System.Collections.Generic;
    using ConsoleWebServer.Framework.HttpSettings;

    public class JsonActionResultWithoutCaching : JsonActionResult
    {
        private const string CacheControl = "Cache-Control";
        private const string Keys = "private, max-age=0, no-cache";

        public JsonActionResultWithoutCaching(HttpRq r, object model) : base(r, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>(CacheControl, Keys));
            throw new Exception();
        }
    }
}
