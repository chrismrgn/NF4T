using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Microsoft.OData.Edm;
using NF4T.OData.Models;

namespace NF4T.OData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("odata", "odata/v4", GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();
        }
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            //builder.Namespace = "NF4T";
            //builder.ContainerName = "DefaultContainer";
            builder.EntitySet<Event>("Events");
            builder.EntitySet<Event>("events");
            builder.EntitySet<CMEnvironment>("CMEnvironments");
            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
    }
}
