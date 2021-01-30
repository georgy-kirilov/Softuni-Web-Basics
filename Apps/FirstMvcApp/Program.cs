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
        const string PageCss = "<style>" +
            "body {" +
            "margin: 50px;" +
            "}</style>";

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
            return new HttpResponse("<h1>Welcome to the Home page</h1>", "text/html");
        }

        static HttpResponse About(HttpRequest request)
        {
            return new HttpResponse("<h1>Welcome to the About page</h1>", "text/html");
        }

        static HttpResponse Login(HttpRequest request)
        {
            string content = "<h1>Login</h1><form method=\"POST\"> " +
                "Username <input/> <br/> <br/>" +
                "Password   <input type=\"password\"/> <br/> <br/>" +
                "<input type=\"submit\" value=\"Send\"/>" +
                "</form>" + PageCss;

            return new HttpResponse(content, "text/html");
        }

        static HttpResponse Favicon(HttpRequest request)
        {
            return new HttpResponse(File.ReadAllBytes("wwwroot/favicon.ico"), "image/vnd.microsoft.icon");
        }
    }
}
