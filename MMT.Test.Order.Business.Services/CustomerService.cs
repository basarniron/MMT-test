using MMT.Test.Order.Business.Contracts.Dtos.Request;
using MMT.Test.Order.Business.Contracts.Interfaces;
using MMT.Test.Order.Integration.Contracts;
using MMT.Test.Order.Integration.Contracts.Messages.Response;
using System;
using System.Threading.Tasks;

namespace MMT.Test.Order.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IOrderIntegrationService _orderIntegrationService;
        public CustomerService(IOrderIntegrationService orderIntegrationService) 
        {
            _orderIntegrationService = orderIntegrationService;
        }

        public async Task<UserDetailsResponse> GetCustomerDetails(RecentOrderRequest request)
        {
            var userDetails = await _orderIntegrationService.GetUserDetails(request.User);           

            return userDetails;
        }
    }
}
