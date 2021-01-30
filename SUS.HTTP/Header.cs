namespace SUS.HTTP
{
    using System;

    public class Header
    {
        private const string HeaderSeparator = ": ";

        public Header(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public Header(string headerString)
        {
            string[] headerArgs = headerString.Split(
                new string[] { HeaderSeparator }, 2, StringSplitOptions.None);

            Name = headerArgs[0];
            Value = headerArgs[1];
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }
    }
}
