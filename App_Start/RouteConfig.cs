    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Xaydung
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}",
               defaults: new { controller = "Home", action = "Index" }
           );

            routes.MapRoute(
                name: "English",
                url: "{lang}/{controller}/{action}",
                defaults: new {lang = "vi", controller = "Home", action = "Index"}               
            );

           
        }
    }
}
