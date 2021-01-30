namespace SUS.HTTP
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class HttpResponse
    {
        private const string DefaultProtocolVersion = "HTTP/1.1";

        public HttpResponse(HttpStatusCode statusCode, string body, string contentType)
        {
            StatusCode = statusCode;
            Body = body;
            ProtocolVersion = DefaultProtocolVersion;
            ContentType = contentType;
        }

        public HttpStatusCode StatusCode { get; }

        public string ProtocolVersion { get; }

        public string Body { get; }

        public string ContentType { get; }

        public ICollection<Header> Headers { get; }

        private Header DateHeader 
            => new Header("Date", DateTime.UtcNow.ToString());

        private Header ServerHeader
            => new Header("Server", "SUS Server");

        private Header ContentLengthHeader
            => new Header("Content-Length", Encoding.UTF8.GetByteCount(Body).ToString());

        private Header ContentTypeHeader
            => new Header("Content-Type", ContentType);

        private string StatusLine
            => $"{ProtocolVersion} {(int)StatusCode} {StatusCode}";

        public override string ToString()
        {
            var responseBuilder = new HttpStringBuilder();

            var list = new object[]
            {
                StatusLine,
                ContentLengthHeader,
                DateHeader,
                ServerHeader,
                ContentTypeHeader,
                HttpConstants.NewLine,
                Body,
            };

            foreach (object item in list)
            {
                responseBuilder.AppendLine(item);
            }

            return responseBuilder.ToString();
        }
    }
}
