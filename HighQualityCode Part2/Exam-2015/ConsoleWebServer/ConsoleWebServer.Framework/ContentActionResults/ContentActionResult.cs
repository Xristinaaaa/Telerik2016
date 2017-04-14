namespace ConsoleWebServer.Framework.ContentActionResults
{
    using System.Collections.Generic;
    using System.Net;
    using Contracts;
    using HttpSettings;

    public class ContentActionResult : IActionResult
    {
        private const string ContentType = "text/plain; charset=utf-8";
        private readonly object model;

        public ContentActionResult(HttpRq request, object model)
        {
            this.model = model;
            this.Request = request;
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

        public HttpRq Request { get; private set; }

        public HttpResponse GetResponse()
        {
            var response = new HttpResponse(this.Request.ProtocolVersion, HttpStatusCode.OK, this.model.ToString(), ContentType);
            foreach (var responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }
    }
}
