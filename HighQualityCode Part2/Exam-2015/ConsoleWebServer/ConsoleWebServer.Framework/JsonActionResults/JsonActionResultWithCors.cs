﻿namespace ConsoleWebServer.Framework.JsonActionResults
{
    using System.Collections.Generic;
    using ConsoleWebServer.Framework.HttpSettings;

    public class JsonActionResultWithCors : JsonActionResult
    {
        public JsonActionResultWithCors(HttpRq request, object model, string corsSettings) : base(request, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        }
    }
}
