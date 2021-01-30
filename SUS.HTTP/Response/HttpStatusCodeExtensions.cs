namespace SUS.HTTP.Response
{
    using System.Text;

    public static class HttpStatusCodeExtensions
    {
        public static string Description(this HttpStatusCode statusCode)
        {
            bool isPreviousLetterLower = false;
            var description = new StringBuilder();

            foreach (char letter in statusCode.ToString())
            {
                if (isPreviousLetterLower && char.IsUpper(letter))
                {
                    description.Append(' ');
                }

                description.Append(letter);
                isPreviousLetterLower = char.IsLower(letter);
            }

            return description.ToString();
        }
    }
}
