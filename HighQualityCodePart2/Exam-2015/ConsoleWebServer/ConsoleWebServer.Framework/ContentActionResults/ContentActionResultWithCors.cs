namespace ConsoleWebServer.Framework.ContentActionResults
{
    using System.Collections.Generic;
    using HttpSettings;

    public class ContentActionResultWithCors<TResult> : ContentActionResult
    {
        private const string Access = "Access-Control-Allow-Origin";

        public ContentActionResultWithCors(HttpRq request, object model, string corsSettings) : base(request, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>(Access, corsSettings));
        }
    }
}
