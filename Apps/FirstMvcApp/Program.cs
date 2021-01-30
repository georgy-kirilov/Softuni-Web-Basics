namespace FirstMvcApp
{
    using System;
    using System.IO;
    using SUS.HTTP;
    using SUS.HTTP.Request;
    using SUS.HTTP.Response;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var server = new HttpServer();

            server.AddRoute("/", Home);
            server.AddRoute("/about", About);
            server.AddRoute("/login", Login);
            server.AddRoute("/favicon.ico", Favicon);

            await server.StartAsync(80);
        }

        static HttpResponse Home(HttpRequest request)
        {
            var response = new HttpResponse(HttpStatusCode.OK);
            response.WriteText("Welcome to the Home Page");
            return response;
        }

        static HttpResponse About(HttpRequest request)
        {
            var response = new HttpResponse(HttpStatusCode.OK);
            response.WriteText("This is our About page", HtmlTag.LargeHeading);
            return response;
        }

        static HttpResponse Login(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        static HttpResponse Favicon(HttpRequest request)
        {
            var response = new HttpResponse(HttpStatusCode.OK, File.ReadAllBytes("wwwroot/favicon.ico"), "image/vnd.microsoft.icon");
            return response;
        }
    }
}
