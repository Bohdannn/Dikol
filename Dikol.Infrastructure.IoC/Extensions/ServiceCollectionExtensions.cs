using Dikol.Core.Interfaces;
using Dikol.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Dikol.Infrastructure.IoC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
