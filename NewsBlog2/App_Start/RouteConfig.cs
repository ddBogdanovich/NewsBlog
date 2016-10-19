using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NewsBlog2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");




            routes.MapRoute(null,
              "", new { controller = "News", action = "List", category = (string)null, page = 1 });

            routes.MapRoute(null,
                "Page{page}",
                new { controller = "News", action = "List", page = 1 });

            routes.MapRoute(null,
                "{category}",
                new { controller = "News", action = "List", page = 1 });

            routes.MapRoute(null,
                "{category}/Page{page}",
                new { controller = "News", action = "List" },
                new { page = @"\d+" });




            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}"
            );











            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
