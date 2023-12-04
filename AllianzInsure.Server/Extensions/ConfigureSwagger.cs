using Microsoft.OpenApi.Models;
namespace AllianzInsure.Server.Extensions
{
    public static class ConfigureSwagger
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            // This method gets called by the runtime from the startup "ConfigureServices()" to add swagger.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Allianz_Insure_Api", Version = "v1" });
            });
        }
    }
}
