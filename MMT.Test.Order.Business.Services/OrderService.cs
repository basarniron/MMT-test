using MMT.Test.Order.Business.Contracts.Dtos.Request;
using MMT.Test.Order.Business.Contracts.Dtos.Response;
using MMT.Test.Order.Business.Contracts.Interfaces;
using MMT.Test.Order.Business.Services.Mappings;
using MMT.Test.Order.Entities.Interfaces;
using MMT.Test.Order.Entities.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMT.Test.Order.Business.Services
{
    public class OrderService : IOrderService
    {        
        private readonly IGenericRepository<Entities.Model.Order> _orderRepository;
        private readonly ICustomerService _customerService;



        public OrderService(IGenericRepository<Entities.Model.Order> orderRepository,
                            ICustomerService customerService) 
        {
            _orderRepository = orderRepository;
            _customerService = customerService;
        }

        public async Task<IReadOnlyList<Entities.Model.Order>> GetAllOrders(string customerId)
        {
            var spec = new AllOrdersOfCustomer(customerId);
            var result = await _orderRepository.ListAsync(spec);
            return result;
        }

        public async Task<ResponseMessage<RecentOrderResponse>> GetRecentOrder(RecentOrderRequest request)
        {
            var userDetails = await _customerService.GetCustomerDetails(request);

            if (userDetails == null || request.CustomerId != userDetails.CustomerId)
            {
                return new ResponseMessage<RecentOrderResponse>(400, "Invalid request");
            }

            var spec = new RecentOrderOfCustomer(userDetails.CustomerId);
            var result = await _orderRepository.GetEntityWithSpec(spec);

            var data = new RecentOrderResponse
            {
                Customer = UserMappings.MapCustomer(userDetails),
                Order = new Contracts.Dtos.OrderDto()
            };

            if (result != null) 
            {
                data.Order = OrderMapping.MapRecentOrder(result, userDetails);                
            }

            var responseMessage = new ResponseMessage<RecentOrderResponse>(200);
            responseMessage.Data = data;
            return responseMessage;
        }
    }
}
