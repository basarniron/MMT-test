using Microsoft.AspNetCore.Mvc;
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
            var recentOrder = await _orderService.GetRecentOrder(request);
            return Ok(recentOrder);
        }

        [HttpPost("order/all")]
        public async Task<ActionResult<Entities.Model.Order>> GetAllOrder()
        {
            var orders = await _orderService.GetAllOrder();
            return Ok(orders);
        }
    }
}
