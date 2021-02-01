namespace FirstMvcApp.Controllers
{
    using SUS.MVC;
    using SUS.HTTP.Request;
    using SUS.HTTP.Response;

    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return Redirect("/home");
        }
    }
}
