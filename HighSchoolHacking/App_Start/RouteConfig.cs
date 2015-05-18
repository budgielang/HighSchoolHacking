using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HighSchoolHacking
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Python",
                "Python/{section}",
                new { 
                    controller = "Python", 
                    action = "Index", 
                    section = "Index" 
                }
            );

            routes.MapRoute(
                "JavaScript",
                "JavaScript/{section}",
                new
                {
                    controller = "JavaScript",
                    action = "Index",
                    section = "Index"
                }
            );

            routes.MapRoute(
                "LOLCODE",
                "LOLCODE/{section}",
                new
                {
                    controller = "LOLCODE",
                    action = "Index",
                    section = "Index"
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { 
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
