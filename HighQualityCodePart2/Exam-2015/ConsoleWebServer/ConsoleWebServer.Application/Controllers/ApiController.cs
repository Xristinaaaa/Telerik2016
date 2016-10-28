namespace WebServer.Application.Controllers
{
    using System;
    using System.Linq;
    using ConsoleWebServer.Framework.JsonActionResults;
    using ConsoleWebServer.Framework.Contracts;
    using ConsoleWebServer.Framework.Controllers;
    using ConsoleWebServer.Framework.HttpSettings;

    public class ApiController : Controller
    {
        private const string RequestReferer = "Referer";
        private const string RefererExc = "Invalid referer!";

        public ApiController(HttpRq request)
            : base(request)
        {
        }

        public IActionResult ReturnMe(string param)
        {
            return this.Json(new { param });
        }

        public IActionResult GetDateWithCors(string domainName)
        {
            var requestReferer = string.Empty;
            if (this.Request.Headers.ContainsKey(RequestReferer))
            {
                requestReferer = this.Request.Headers[requestReferer].FirstOrDefault();
            }

            if (string.IsNullOrWhiteSpace(requestReferer) || !requestReferer.Contains(domainName))
            {
                throw new ArgumentException(RefererExc);
            }

            return new JsonActionResultWithCors(this.Request, new { date = DateTime.Now.ToString("yyyy-MM-dd"), moreInfo = "Data available for " + domainName }, domainName);
        }
    }
}