using Microsoft.AspNetCore.Mvc;
using MMT.Test.Order.Api.Errors;
using MMT.Test.Order.Business.Contracts.Dtos.Request;
using MMT.Test.Order.Business.Contracts.Dtos.Response;
using MMT.Test.Order.Business.Contracts.Interfaces;
using System.Threading.Tasks;

namespace MMT.Test.Order.Api.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }

        [HttpPost("order/recent")]
        public async Task<ActionResult<RecentOrderResponse>> GetMostRecentOrder([FromBody] RecentOrderRequest request)
        {
            if (request == null || 
                string.IsNullOrEmpty(request.CustomerId) || 
                string.IsNullOrEmpty(request.User))
            {
                return ReturnBadRequest(Core.Constants.Errors.InvalidRequest);
            }

            var recentOrder = await _orderService.GetRecentOrder(request);
            if (recentOrder.StatusCode == 400) 
            {
                return ReturnBadRequest(Core.Constants.Errors.InvalidRequest);
            }

            return Ok(recentOrder.Data);
        }

        [HttpPost("order/{customerId}/all")]
        public async Task<ActionResult<Entities.Model.Order>> GetAllOrders(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return ReturnBadRequest(Core.Constants.Errors.InvalidRequest);
            }

            var orders = await _orderService.GetAllOrders(customerId);
            return Ok(orders);
        }
    }
}
