using System.Reflection;
using Microsoft.OpenApi;

namespace AspireFun.Server.Extensions;

public static class RandomExtension
{
    public static bool NextBool(this Random random)
    {
        return random.Next(0, 2) == 1;
    }

    /// <summary>
    /// Adds AddSwaggerGen() with some customization.
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    /// <returns>IServiceCollection with AddSwaggerGen() configured.</returns>
    public static IServiceCollection AddMySwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Version = "V1",
                Title = "My Test Api",
            });

            // this following allows swagger to include the XML comments details in the UI such as example values or descriptions. 
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
        return services;
    }
}