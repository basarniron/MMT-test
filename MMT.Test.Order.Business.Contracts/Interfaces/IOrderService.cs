using MMT.Test.Order.Business.Contracts.Dtos.Request;
using MMT.Test.Order.Business.Contracts.Dtos.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMT.Test.Order.Business.Contracts.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseMessage<RecentOrderResponse>> GetRecentOrder(RecentOrderRequest request);

        Task<IReadOnlyList<Entities.Model.Order>> GetAllOrders(string customerId);
    }
}
