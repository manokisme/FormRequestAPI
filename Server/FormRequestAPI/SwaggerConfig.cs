using System.Web.Http;
using WebActivatorEx;
using Swashbuckle.Application;
using FormRequestAPI;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace FormRequestAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "FormRequestAPI");
                })
                .EnableSwaggerUi();
        }
    }
}
