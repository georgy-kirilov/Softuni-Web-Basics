namespace SUS.HTTP
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class HttpRequest
    {
        public HttpRequest(string rawRequestString)
        {
            Headers = new List<Header>();
            Cookies = new List<Cookie>();

            string[] requestLines = rawRequestString.Split(
                new[] { HttpConstants.NewLine }, StringSplitOptions.None);

            string[] firstLineArgs = requestLines[0].Split(HttpConstants.FirstLineSeparator);

            Method = (HttpMethod)Enum.Parse(
                typeof(HttpMethod), firstLineArgs[0], ignoreCase: true);
            
            Route = firstLineArgs[1];

            ProtocolVersion = firstLineArgs[2];

            bool inHeaders = true;
            int lineNumber = 1;

            var requestBodyBuilder = new StringBuilder();

            while (lineNumber < requestLines.Length)
            {
                string currentLine = requestLines[lineNumber];
                lineNumber++;

                if (string.IsNullOrWhiteSpace(currentLine))
                {
                    inHeaders = false;
                    continue;
                }

                if (inHeaders)
                {
                    Header header = new Header(currentLine);
                    Headers.Add(header);

                    if (header.Name == HttpConstants.RequestCookieHeaderName)
                    {
                        var rawCookies = header.Value.Split(new[] { Cookie.Separator }, 
                            StringSplitOptions.RemoveEmptyEntries);

                        foreach (string rawCookie in rawCookies)
                        {
                            Cookies.Add(new Cookie(rawCookie));
                        }
                    }
                }
                else
                {
                    requestBodyBuilder.AppendLine(currentLine);
                }
            }

            Body = requestBodyBuilder.ToString();
        }

        public HttpMethod Method { get; }

        public string Route { get; }

        public string ProtocolVersion { get; }

        public ICollection<Header> Headers { get; }

        public ICollection<Cookie> Cookies { get; }

        public string Body { get; }
    }
}
