namespace FirstMvcApp
{
    using System;
    using SUS.HTTP;
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
            throw new NotImplementedException();
        }

        static HttpResponse About(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        static HttpResponse Login(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        static HttpResponse Favicon(HttpRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
