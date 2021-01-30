namespace SUS.HTTP
{
    public class Cookie
    {
        public const string Separator = "; ";
        private const char NameValueSeparator = '=';

        public Cookie(string rawCookieString)
        {
            string[] cookieArgs = rawCookieString.Split(NameValueSeparator);
            Name = cookieArgs[0];
            Value = cookieArgs[1];
        }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
