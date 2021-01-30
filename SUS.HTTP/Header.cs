namespace SUS.HTTP
{
    using System;

    public class Header
    {
        private const string NameValueSeparator = ": ";

        public Header(string name, object value)
        {
            Name = name;
            Value = value.ToString();
        }

        public Header(string rawHeaderString)
        {
            var headerArgs = rawHeaderString.Split(
                new[] { NameValueSeparator }, 2, StringSplitOptions.None);

            Name = headerArgs[0];
            Value = headerArgs[1];
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Name}{NameValueSeparator}{Value}";
        }
    }
}
