namespace SUS.HTTP.Response
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using SUS.HTTP.Common;

    public class HttpResponse
    {
        public HttpResponse(string body, string contentType, HttpStatusCode statusCode = HttpStatusCode.OK)
            : this(Encoding.UTF8.GetBytes(body), contentType, statusCode)
        {
        }

        public HttpResponse(byte[] body, string contentType, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Headers = new List<Header>();

            Body = body ?? new byte[0];
            ContentType = contentType ?? HttpContentType.Plain;
            StatusCode = statusCode;
        }

        public byte[] Body { get; set; }

        public string ContentType { get; private set; }

        public HttpStatusCode StatusCode { get; }

        public ICollection<Header> Headers { get; }

        public override string ToString()
        {
            var responseBuilder = new HttpResponseBuilder();

            responseBuilder.AppendStatusLine(StatusCode);

            responseBuilder.AppendHeader(new Header("Date", DateTime.UtcNow));
            responseBuilder.AppendHeader(new Header("Server", "SUS Server"));
            responseBuilder.AppendHeader(new Header("Content-Length", Body.Length));
            responseBuilder.AppendHeader(new Header("Content-Type", ContentType));

            foreach (Header header in Headers)
            {
                responseBuilder.AppendHeader(header);
            }

            responseBuilder.AppendLine();
            return responseBuilder.ToString();
        }
    }
}
