using MMT.Test.Order.Business.Contracts.Dtos;
using MMT.Test.Order.Business.Contracts.Dtos.Request;
using MMT.Test.Order.Business.Contracts.Dtos.Response;
using MMT.Test.Order.Core.Constants;
using MMT.Test.Order.Core.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MMT.Test.Order.Business.Services.Mappings
{
    public static class OrderMapping
    {
        public static RecentOrderResponse Map(this RecentOrderRequest request, Entities.Model.Order order)
        {
            RecentOrderResponse response = new RecentOrderResponse
            {
                Customer = new CustomerDto(),
                Order = new OrderDto
                {
                    OrderNumber = order.Orderid,
                    OrderDate = order.Orderdate.Value.ToFormattedString(),
                    DeliveryAddress = "TODO", //customer data
                    DeliveryExpected = order.Deliveryexpected.Value.ToFormattedString(),
                    OrderItems = MapOrderItems(order.Orderitems.ToList(), order.Containsgift.Value)
                }
            };

            return response;
        }

        private static IList<OrderItemDto> MapOrderItems(IList<Entities.Model.Orderitem> orderItems, bool containsGift)
        {
            var result = (from item
                         in orderItems
                         select new OrderItemDto
                         {
                             Product = SetProductName(item.Product.Productname, containsGift),
                             Quantity = item.Quantity.Value,
                             PriceEach = item.Price.Value
                         }).ToList();

            return result;
        }

        private static string SetProductName(string productName, bool containsGift) 
        {
            return containsGift ? OrderConstants.Gift : productName;
        }
    }
}
