namespace SUS.HTTP
{
    using System;
    using System.Text;

    public class ResponseCookie
    {
        const string HeaderName = "Set-Cookie";

        public ResponseCookie(string name, string value)
        {
            Name = name;
            Value = value;
            MaxAge = null;
        }

        public string Name { get; }

        public string Value { get; }

        public int? MaxAge { get; set; }

        public string Path { get; set; }

        public bool Secure { get; set; }

        public bool HttpOnly { get; set; }

        public string Domain { get; set; }

        public DateTime? Expires { get; set; }

        public SameSite SameSite { get; set; }

        public override string ToString()
        {
            var cookieBuilder = new StringBuilder();

            cookieBuilder.Append($"{HeaderName}: {Name}={Value} ");

            if (HttpOnly)
            {
                cookieBuilder.Append("HttpOnly; ");
            }

            if (MaxAge != null)
            {
                cookieBuilder.Append($"MaxAge={MaxAge}; ");
            }

            if (Expires != null)
            {
                cookieBuilder.Append($"Expires={Expires?.ToString("R")}; ");
            }

            return base.ToString();
        }
    }
}
