using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AgeOfTotalConquest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name:"User",
                url: "user/{id}",
                defaults: new{controller = "Registration", action = "User" });

            routes.MapRoute
                (
                name:"UserModel",
                url:"usermodel/{id}",
                defaults: new {controller = "Registration", action = "UserModel" }
                );


            routes.MapRoute
                (
                name:"Units",
                url:"units",
                defaults: new { controller = "Home", action = "Units" });



            routes.MapRoute(
                name: "Registration",
                url: "registration/{username}/{email}/{password}",
                defaults: new { controller = "Registration", action = "SingUp" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
