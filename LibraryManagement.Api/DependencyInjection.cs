using LibraryManagement.Application;
using LibraryManagement.Infrastructure;

namespace LibraryManagement.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI();
            return services;
        }
    }
}
