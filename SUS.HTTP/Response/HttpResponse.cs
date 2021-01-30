namespace SUS.HTTP.Response
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using SUS.HTTP.Common;

    public class HttpResponse
    {
        private readonly StringBuilder bodyBuilder;

        public HttpResponse(HttpStatusCode statusCode)
            : this(statusCode, string.Empty, "text/plain")
        {
        }

        public HttpResponse(HttpStatusCode statusCode, byte[] bodyBytes, string contentType)
            : this(statusCode, Encoding.UTF8.GetString(bodyBytes), contentType)
        {
        }

        public HttpResponse(HttpStatusCode statusCode, string body, string contentType)
        {
            Headers = new List<Header>();
            bodyBuilder = new StringBuilder(body);
            StatusCode = statusCode;
            ContentType = contentType;
        }

        public string Body => bodyBuilder.ToString();

        public HttpStatusCode StatusCode { get; }

        public string ContentType { get; private set; }

        public ICollection<Header> Headers { get; }

        public void WriteText(string text, HtmlTag tag = HtmlTag.None)
        {
            if (tag != HtmlTag.None)
            {
                ContentType = "text/html";
                bodyBuilder.Append($"<{tag.AsText()}>{text}</{tag.AsText()}>");
            }
            else
            {
                bodyBuilder.Append(text);
            }
        }

        public override string ToString()
        {
            var responseBuilder = new HttpResponseBuilder();

            responseBuilder.AppendStatusLine(StatusCode);

            responseBuilder.AppendHeader(new Header("Date", DateTime.UtcNow));
            responseBuilder.AppendHeader(new Header("Server", "SUS Server"));
            responseBuilder.AppendHeader(new Header("Content-Length", Encoding.UTF8.GetByteCount(Body)));
            responseBuilder.AppendHeader(new Header("Content-Type", ContentType));

            foreach (Header header in Headers)
            {
                responseBuilder.AppendHeader(header);
            }

            responseBuilder.AppendBody(Body);
            return responseBuilder.ToString();
        }
    }
}
