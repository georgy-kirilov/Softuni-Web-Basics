namespace SUS.HTTP.Common
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SUS.HTTP.Request;
    using SUS.HTTP.Response;

    public class RouteTable
    {
        private readonly ICollection<Route> routes;

        public RouteTable(bool replaceExistingRoutes = true)
        {
            routes = new List<Route>();
            ReplaceExistingRoutes = replaceExistingRoutes;
        }

        public bool ReplaceExistingRoutes { get; }

        public ICollection<Route> Routes => routes.ToList().AsReadOnly();

        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action, HttpMethod method = HttpMethod.Get)
        {
            var newRoute = new Route(method, path, action);

            Route currentRoute = routes.FirstOrDefault(x =>
                string.Compare(x.Path, newRoute.Path, ignoreCase: true) == 0 &&
                x.Method == newRoute.Method);

            if (currentRoute != null && !ReplaceExistingRoutes)
            {
                throw new ArgumentException("Cannot add already existing route");
            }

            routes.Remove(currentRoute);
            routes.Add(newRoute);
        }
    }
}
