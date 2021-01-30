namespace SUS.HTTP
{
    using System.Text;

    public sealed class HttpStringBuilder
    {
        private readonly StringBuilder httpBuilder;

        public HttpStringBuilder()
        {
            httpBuilder = new StringBuilder();
        }

        public void AppendLine(object value)
        {
            httpBuilder.Append($"{value}{HttpConstants.NewLine}");
        }

        public void AppendLine()
        {
            httpBuilder.Append(HttpConstants.NewLine);
        }

        public override string ToString()
        {
            return httpBuilder.ToString();
        }
    }
}
