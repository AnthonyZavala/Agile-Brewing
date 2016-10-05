using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using WebApplication.Models;
using Microsoft.OData.Edm;

namespace WebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.MaxTop(100);
            config.MapODataServiceRoute("odata", "odata", GetEdmModel());
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "AgileBrewing";
            builder.ContainerName = "AgileBreaingContainer";
            
            builder.EntitySet<Recipe>("Recipes");
            builder.EntityType<Recipe>().Filter("Name");
            builder.ComplexType<Style>();

            return builder.GetEdmModel();
        }
    }
}
