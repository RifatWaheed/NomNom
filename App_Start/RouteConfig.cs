using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NomNomScratch
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Customer/CustomerAppetizer", "Customer/CustomerAppetizer/{id}",
               new
               {
                   Controller = "Customer",
                   action = "CustomerAppetizer",
                   id = UrlParameter.Optional
               });

            routes.MapRoute("Customer/CustomerAppetizerMinus", "Customer/CustomerAppetizerMinus/{id}",
                new
                {
                    Controller = "Customer",
                    action = "CustomerAppetizerMinus",
                    id = UrlParameter.Optional
                });


            routes.MapRoute("Customer/CustomerMainCourse", "Customer/CustomerMainCourse/{id}",
                new
                {
                    Controller = "Customer",
                    action = "CustomerMainCourse",
                    id = UrlParameter.Optional
                });
            routes.MapRoute("Customer/CustomerMainCourseMinus", "Customer/CustomerMainCourseMinus/{id}",
                new
                {
                    Controller = "Customer",
                    action = "CustomerMainCourseMinus",
                    id = UrlParameter.Optional
                });




            routes.MapRoute("Customer/CustomerBeverage", "Customer/CustomerBeverage/{id}",
                new
                {
                    Controller = "Customer",
                    action = "CustomerBeverage",
                    id = UrlParameter.Optional
                });
            routes.MapRoute("Customer/CustomerBeverageMinus", "Customer/CustomerBeverageMinus/{id}",
                new
                {
                    Controller = "Customer",
                    action = "CustomerBeverageMinus",
                    id = UrlParameter.Optional
                });






            routes.MapRoute("Customer/CustomerDessert", "Customer/CustomerDessert/{id}",
                new
                {
                    Controller = "Customer",
                    action = "CustomerDessert",
                    id = UrlParameter.Optional
                });
            routes.MapRoute("Customer/CustomerDessertMinus", "Customer/CustomerDessertMinus/{id}",
                new
                {
                    Controller = "Customer",
                    action = "CustomerDessertMinus",
                    id = UrlParameter.Optional
                });
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
