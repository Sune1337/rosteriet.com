namespace CoffeeShop
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        #region Public Methods and Operators

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Pricelist",
                url: "Templates/Kaffe/Prislista",
                defaults: new { controller = "Pricelist", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Default",
                url: "{*url}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        #endregion
    }
}
