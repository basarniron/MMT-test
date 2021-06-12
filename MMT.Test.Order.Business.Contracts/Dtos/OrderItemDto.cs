namespace MMT.Test.Order.Business.Contracts.Dtos
{
    public class OrderItemDto
    {
        public string Product { get; set; }

        public int Quantity { get; set; }

        public decimal PriceEach { get; set; }
    }
}
