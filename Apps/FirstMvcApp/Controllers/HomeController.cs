namespace FirstMvcApp.Controllers
{
    using SUS.HTTP.Request;
    using SUS.HTTP.Response;
    using SUS.MVC;

    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            return View();
        }
    }
}
