﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MynfoBack
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{param2}",
                defaults: new { controller = "Home", 
                    action = "Index", 
                    id = UrlParameter.Optional, 
                    param2= UrlParameter.Optional }
            );
        }
    }
}
