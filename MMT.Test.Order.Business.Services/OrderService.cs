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
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IGenericRepository<Entities.Model.Order> orderRepository) 
        {
            _orderRepository = orderRepository;
        }

        public async Task<IReadOnlyList<Entities.Model.Order>> GetAllOrder()
        {
            var spec = new RecentOrderOfCustomer("C34454");
            var result = await _orderRepository.ListAsync(spec);
            return result;

            //var result = await _orderRepository.ListAllAsync();
            //return result;
        }

        public async Task<RecentOrderResponse> GetRecentOrder(RecentOrderRequest request)
        {
            var spec = new RecentOrderOfCustomer("C34454");
            var result = await _orderRepository.GetEntityWithSpec(spec);

            RecentOrderResponse response = request.Map(result);

            return response;
        }
    }
}
