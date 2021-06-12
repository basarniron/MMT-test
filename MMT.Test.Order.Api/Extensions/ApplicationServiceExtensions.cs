using Microsoft.Extensions.DependencyInjection;
using MMT.Test.Order.Business.Contracts.Interfaces;
using MMT.Test.Order.Business.Services;
using MMT.Test.Order.Entities;
using MMT.Test.Order.Entities.Interfaces;

namespace MMT.Test.Order.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
           
            return services;
        }
    }
}
