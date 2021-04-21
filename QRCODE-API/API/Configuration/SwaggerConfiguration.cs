using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace QRCODE_API.API.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QRCode API", Version = "v1" });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocument(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "QrCode API v1");
            });
            return app;
        }
    }
}
