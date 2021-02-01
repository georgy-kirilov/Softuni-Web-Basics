namespace SUS.HTTP
{
    public class Cookie
    {
        public const string Separator = "; ";

        public Cookie(string rawCookieString)
        {
            string[] cookieArgs = rawCookieString.Split('=');
            Name = cookieArgs[0];
            Value = cookieArgs[1];
        }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
