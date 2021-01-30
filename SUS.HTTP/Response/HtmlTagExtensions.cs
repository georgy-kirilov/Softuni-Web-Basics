namespace SUS.HTTP.Response
{
    using System;

    public static class HtmlTagExtensions
    {
        public static string AsText(this HtmlTag tag)
        {
            switch (tag)
            {
                case HtmlTag.None:
                    return string.Empty;

                case HtmlTag.Bold:
                    return "b";

                case HtmlTag.Italic:
                    return "i";

                case HtmlTag.Paragraph:
                    return "p";

                case HtmlTag.Underline:
                    return "u";

                case HtmlTag.TinyHeading:
                    return "h6";

                case HtmlTag.LargeHeading:
                    return "h1";

                case HtmlTag.MediumHeading:
                    return "h3";

                default:
                    throw new ArgumentException($"Invalid {nameof(HtmlTag)} value");
            }
        }
    }
}
