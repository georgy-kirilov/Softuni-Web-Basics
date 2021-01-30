namespace SUS.HTTP
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class HttpResponse
    {
        public HttpResponse(HttpStatusCode statusCode, string body, string contentType)
        {
            Headers = new List<Header>();

            Body = body;
            StatusCode = statusCode;
            ContentType = contentType;
        }

        public string Body { get; }

        public HttpStatusCode StatusCode { get; }

        public string ContentType { get; }

        public ICollection<Header> Headers { get; }

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
