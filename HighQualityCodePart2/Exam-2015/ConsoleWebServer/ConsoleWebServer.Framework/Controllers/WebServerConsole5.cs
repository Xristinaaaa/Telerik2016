namespace ConsoleWebServer.Framework.Controllers
{
    using System;
    using System.Text;

    public class WebServerConsole5
    {
        private readonly ResponseProvider responseProvider;

        public WebServerConsole5()
        {
            this.responseProvider = new ResponseProvider();
        }

        public void Start()
        {
            var requestBuilder = new StringBuilder();
            var inputLine = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputLine))
            {
                var response = this.responseProvider.GetResponse(requestBuilder.ToString());
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(response);
                Console.ResetColor();
                requestBuilder.Clear();
                requestBuilder.AppendLine(inputLine);
            }
            else
            {
                throw new NullReferenceException("Null input!");
            }
        }
    }
}