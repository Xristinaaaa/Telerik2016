namespace ConsoleWebServer.Framework.HttpSettings
{
    using System;
    using ConsoleWebServer.Framework.Actions;

    public class HttpNotFound : Exception
    {
        public HttpNotFound(string message) : base(message)
        {
        }

        public class ParserException : Exception
        {
            public ParserException(string message, ActionDescriptor request = null) : base(message)
            {
            }
        }
    }
}