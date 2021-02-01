namespace SUS.MVC
{
    using System.IO;
    using SUS.HTTP.Common;
    using SUS.HTTP.Response;
    using System.Runtime.CompilerServices;

    public class Controller
    {
        public HttpResponse View([CallerMemberName] string actionName = null)
        {
            string viewName = GetType().Name.Replace("Controller", string.Empty);
            string viewPath = $"Views/{viewName}/{actionName}.cshtml";
            byte[] bodyBytes = File.ReadAllBytes(viewPath);
            return new HttpResponse(bodyBytes, HttpContentType.Html);
        }

        public HttpResponse Redirect(string route)
        {
            byte[] bodyBytes = File.ReadAllBytes(route);
            var response = new HttpResponse(bodyBytes, HttpContentType.Html, HttpStatusCode.Found);
            response.Headers.Add(new Header("Location", route));
            return response;
        }
    }
}
