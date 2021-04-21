using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using QRCODE_API.API.Configuration;
using QRCODE_API.Configuration;
using QRCODE_API.ErrorHandler;
using QRCODE_API.Inventory;

namespace QRCODE_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                });

            // add swagger configuration
            services.AddSwaggerConfiguration();
            services.AddDbContext<InventoryContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SQLServerConnection")));

            services.ApplicationService();
            services.AddAutoMapper(typeof(MappingConfiguration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.ConfigureExceptionHandler();

            // config cors
            app.UseCors(cor => cor
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins("http://localhost:3000")
            );

            // build swagger
            app.UseSwaggerDocument();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}