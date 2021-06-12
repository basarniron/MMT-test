namespace MMT.Test.Order.Entities.Specifications
{
    public class RecentOrderOfCustomer : BaseSpecifcation<Model.Order>
    {
        public RecentOrderOfCustomer(string customerId) : base(o => o.Customerid == customerId)
        {
            AddInclude(o => o.Orderitems);
            AddInclude($"{nameof(Model.Order.Orderitems)}.{nameof(Model.Orderitem.Product)}");
            AddOrderByDescending(o => o.Orderdate);
            AddTake(1);
        }
    }
}
