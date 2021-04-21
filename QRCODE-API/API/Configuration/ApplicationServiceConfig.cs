using Microsoft.Extensions.DependencyInjection;

using QRCODE_API.Core.Interface.service;
using QRCODE_API.Infrastructure.Services;
using QRCODE_API.Interface.repo;
using QRCODE_API.Interface.service;
using QRCODE_API.Services;

namespace QRCODE_API.Configuration
{
    public static class ApplicationServiceConfig
    {
        public static IServiceCollection ApplicationService(this IServiceCollection services)
        {

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IRoleService, RoleServiceImpl>();
            services.AddScoped<IUserService, UserServiceImpl>();

            return services;
        }
    }
}
