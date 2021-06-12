using System;
using System.Collections.Generic;

namespace MMT.Test.Order.Business.Contracts.Dtos
{
    public class OrderDto
    {
        public int OrderNumber { get; set; }

        public string OrderDate { get; set; }

        public string DeliveryAddress { get; set; }

        public IList<OrderItemDto> OrderItems { get; set; }

        public string DeliveryExpected { get; set; }
    }
}
