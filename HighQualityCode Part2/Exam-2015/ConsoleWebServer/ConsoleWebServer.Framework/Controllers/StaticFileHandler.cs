﻿namespace ConsoleWebServer.Framework.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using ConsoleWebServer.Framework.HttpSettings;

    public class StaticFileHandler
    {
        public bool CanHandle(HttpRq request)
        {
            return request.Uri.LastIndexOf(".", StringComparison.Ordinal) > request.Uri.LastIndexOf("/", StringComparison.Ordinal);
        }

        public HttpResponse Handle(HttpRq request)
        {
            String filePath = Environment.CurrentDirectory + "/" + request.Uri;
            if (!this.FileExists("C:\\", filePath, 3))
            {
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, "File not found");
            }

            String fileContents = File.ReadAllText(filePath);
            var response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, fileContents);
            return response;
        }

        private bool FileExists(String path, String filePath, int depth)
        {
            if (depth <= 0)
            {
                return File.Exists(filePath);
            }

            try
            {
                var file = Directory.GetFiles(path);
                if (file.Contains(filePath))
                {
                    return true;
                }

                var directories = Directory.GetDirectories(path);
                foreach (var directory in directories)
                {
                    if (this.FileExists(directory, filePath, depth - 1))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}