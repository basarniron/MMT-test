namespace MMT.Test.Order.Entities.Specifications
{
    public class AllOrdersOfCustomer : BaseSpecifcation<Model.Order>
    {
        public AllOrdersOfCustomer(string customerId) : base(o => o.Customerid == customerId)
        {
            AddInclude(o => o.Orderitems);
            AddInclude($"{nameof(Model.Order.Orderitems)}.{nameof(Model.Orderitem.Product)}");
        }
    }
}
