namespace WebServer.Application.Controllers
{
    using ConsoleWebServer.Framework.ContentActionResults;
    using ConsoleWebServer.Framework.Contracts;
    using ConsoleWebServer.Framework.Controllers;
    using ConsoleWebServer.Framework.HttpSettings;

    public class HomeController : Controller
    {
        private const string HomePage = "Home page :)";

        public HomeController(HttpRq request)
            : base(request)
        {
        }

        public IActionResult Index(string param)
        {
            return this.Content(HomePage);
        }

        public IActionResult LivePage(string param)
        {
            return new ContentActionResultWithoutCaching(this.Request, "Live page with no caching");
        }

        public IActionResult LivePageForAjax(string param)
        {
            return new ContentActionResultWithCorsWithoutCaching(this.Request, "Live page with no caching and CORS", "*");
        }
    }
}
