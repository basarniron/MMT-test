using Microsoft.Extensions.DependencyInjection;
using MMT.Test.Order.Business.Contracts.Interfaces;
using MMT.Test.Order.Business.Services;
using MMT.Test.Order.Core.Http;
using MMT.Test.Order.Entities;
using MMT.Test.Order.Entities.Interfaces;
using MMT.Test.Order.Integration.Contracts;
using MMT.Test.Order.Integration.Services;

namespace MMT.Test.Order.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {            
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IHttpClientHelper, HttpClientHelper>();
            services.AddScoped<IOrderIntegrationService, OrderIntegrationService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
           
            return services;
        }
    }
}
