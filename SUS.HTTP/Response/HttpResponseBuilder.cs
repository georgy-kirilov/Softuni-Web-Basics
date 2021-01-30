namespace SUS.HTTP.Response
{
    using System.Text;
    using SUS.HTTP.Common;

    public class HttpResponseBuilder
    {
        private readonly StringBuilder responseBuilder;

        public HttpResponseBuilder()
        {
            responseBuilder = new StringBuilder();
        }

        public void AppendStatusLine(HttpStatusCode statusCode)
        {
            AppendLine($"{HttpConstants.ProtocolVersion} {(int)statusCode} {statusCode.Description()}");
        }

        public void AppendHeader(Header header)
        {
            AppendLine(header);
        }

        public void AppendBody(string body)
        {
            AppendLine(string.Empty);
            AppendLine(body);
        }

        private void AppendLine(object value)
        {
            responseBuilder.Append($"{value}{HttpConstants.NewLine}");
        }

        public override string ToString()
        {
            return responseBuilder.ToString();
        }
    }
}
