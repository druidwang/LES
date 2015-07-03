﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SconitWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default", // Route name
                url: "{controller}/{action}/{id}", // URL with parameters
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }
    }
}