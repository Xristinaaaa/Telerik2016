namespace ConsoleWebServer.Framework.ContentActionResults
{
    using System.Collections.Generic;
    using HttpSettings;

    public class ContentActionResultWithCorsWithoutCaching : ContentActionResult
    {
        private const string Access = "Access-Control-Allow-Origin";
        private const string CacheControl = "Cache-Control";
        private const string Keys = "private, max-age=0, no-cache";

        public ContentActionResultWithCorsWithoutCaching(HttpRq request, object model, string corsSettings) 
            : base(request, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>(Access, corsSettings));
            this.ResponseHeaders.Add(new KeyValuePair<string, string>(CacheControl, Keys));
        }
    }
}
