using LibraryManagement.Api.Services;
using LibraryManagement.Application;
using LibraryManagement.Core.Interfaces;
using LibraryManagement.Infrastructure;

namespace LibraryManagement.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI(configuration);
            services.AddSingleton<IAppEnvironment, AppEnvironment>();
            return services;
        }
    }
}
