using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBankingASP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Banchiere1.0",
                url: "Banchiere/conti-correnti",
                defaults: new { controller = "Banchiere", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Banchiere2.0",
                url: "Banchiere/conti-correnti/{id}",
                defaults: new { controller = "Banchiere", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Banchiere3.0",
                url: "Banchiere/conti-correnti/{id}/movimenti",
                defaults: new { controller = "Banchiere", action = "Movimenti", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Banchiere4.0",
                url: "Banchiere/conti-correnti/{id1}/movimenti/{id2}",
                defaults: new { controller = "Banchiere", action = "Movimento", id1 = UrlParameter.Optional, id2 = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Banchiere5.0",
                url: "Banchiere/conti-correnti/{id}/bonifico",
                defaults: new { controller = "Banchiere", action = "Bonifico", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Banchiere1.1",
                url: "Correntista/conti-correnti",
                defaults: new { controller = "Correntista", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Banchiere2.1",
                url: "Correntista/conti-correnti/{id}",
                defaults: new { controller = "Correntista", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Banchiere3.1",
                url: "Correntista/conti-correnti/{id}/movimenti",
                defaults: new { controller = "Correntista", action = "Movimenti", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Banchiere4.1",
                url: "Correntista/conti-correnti/{id1}/movimenti/{id2}",
                defaults: new { controller = "Correntista", action = "Movimento", id1 = UrlParameter.Optional, id2 = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Banchiere5.1",
                url: "Correntista/conti-correnti/{id}/bonifico",
                defaults: new { controller = "Correntista", action = "Bonifico", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Deafault",
                url: "Account/Login",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "Default2",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
        }
    }
}
