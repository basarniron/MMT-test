using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MMT.Test.Order.Entities.Model
{
    [Table("ORDERS")]
    public partial class Order : BaseEntity
    {
        public Order()
        {
            Orderitems = new HashSet<Orderitem>();
        }

        [Key]
        [Column("ORDERID")]
        public int Orderid { get; set; }
        [Column("CUSTOMERID")]
        [StringLength(10)]
        public string Customerid { get; set; }
        [Column("ORDERDATE", TypeName = "date")]
        public DateTime? Orderdate { get; set; }
        [Column("DELIVERYEXPECTED", TypeName = "date")]
        public DateTime? Deliveryexpected { get; set; }
        [Column("CONTAINSGIFT")]
        public bool? Containsgift { get; set; }
        [Column("SHIPPINGMODE")]
        [StringLength(30)]
        public string Shippingmode { get; set; }
        [Column("ORDERSOURCE")]
        [StringLength(30)]
        public string Ordersource { get; set; }

        [InverseProperty(nameof(Orderitem.Order))]
        public virtual ICollection<Orderitem> Orderitems { get; set; }
    }
}
