namespace SUS.HTTP.Common
{
    using System;
    using SUS.HTTP.Request;
    using SUS.HTTP.Response;

    public class Route
    {
        public Route(string path, Func<HttpRequest, HttpResponse> action) 
            : this(HttpMethod.Get, path, action)
        {
        }

        public Route(HttpMethod method, string path, Func<HttpRequest, HttpResponse> action)
        {
            if (path == null || path.Trim() == string.Empty)
            {
                throw new ArgumentException("Path cannot be null empty or white space");
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            Path = path;
            Method = method;
            Action = action;
        }

        public string Path { get; }

        public HttpMethod Method { get; }

        public Func<HttpRequest, HttpResponse> Action { get; }
    }
}
