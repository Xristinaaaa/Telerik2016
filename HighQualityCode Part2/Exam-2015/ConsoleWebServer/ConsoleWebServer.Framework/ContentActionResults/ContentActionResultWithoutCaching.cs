namespace ConsoleWebServer.Framework.ContentActionResults
{
    using System.Collections.Generic;
    using HttpSettings;

    public class ContentActionResultWithoutCaching : ContentActionResult
    {
        private const string CacheControl = "Cache-Control";
        private const string Keys = "private, max-age=0, no-cache";

        public ContentActionResultWithoutCaching(HttpRq request, object model) : base(request, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>(CacheControl, Keys));
        }
    }
}
