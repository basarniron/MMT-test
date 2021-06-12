using MMT.Test.Order.Business.Contracts.Dtos;
using MMT.Test.Order.Core.Constants;
using MMT.Test.Order.Core.Extensions;
using MMT.Test.Order.Integration.Contracts.Messages.Response;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMT.Test.Order.Business.Services.Mappings
{
    public static class OrderMapping
    {
        public static OrderDto MapRecentOrder(Entities.Model.Order order,
                                              UserDetailsResponse userDetails)
        {
            return new OrderDto
            {
                OrderNumber = order.Orderid,
                OrderDate = order.Orderdate.Value.ToFormattedString(),
                DeliveryAddress = SetDeliveryAddress(userDetails),
                DeliveryExpected = order.Deliveryexpected.HasValue ? order.Deliveryexpected.Value.ToFormattedString() : string.Empty,
                OrderItems = MapOrderItems(order.Orderitems.ToList(), order.Containsgift.Value)
            };
        }

        private static string SetDeliveryAddress(UserDetailsResponse userDetails)
        {
            var address = new StringBuilder();
            if (!string.IsNullOrEmpty(userDetails.HouseNumber))
            {
                address.AppendFormat("{0} ", userDetails.HouseNumber.ToUpper());
            }

            if (!string.IsNullOrEmpty(userDetails.Street))
            {
                address.AppendFormat("{0}, ", userDetails.Street);
            }

            if (!string.IsNullOrEmpty(userDetails.Town))
            {
                address.AppendFormat("{0}, ", userDetails.Town);
            }
            if (!string.IsNullOrEmpty(userDetails.Postcode))
            {
                address.Append(userDetails.Postcode);
            }

            return address.ToString();
        }

        private static IList<OrderItemDto> MapOrderItems(IList<Entities.Model.Orderitem> orderItems, bool containsGift)
        {
            var result = (from item
                         in orderItems
                          select new OrderItemDto
                          {
                              Product = SetProductName(item.Product.Productname, containsGift),
                              Quantity = item.Quantity.HasValue ? item.Quantity.Value : 0,
                              PriceEach = item.Price.HasValue ? item.Price.Value : 0.0M
                          }).ToList();

            return result;
        }

        private static string SetProductName(string productName, bool containsGift)
        {
            return containsGift ? OrderConstants.Gift : productName;
        }
    }
}
