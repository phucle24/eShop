using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Enitities
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }
        public Guid UserId { set; get; }
        public string ShipName { set; get; }
        public string ShipAdress { set; get; }
        public string ShipPhone { set; get; }
        public string ShipEmail { set; get; }
        public OrderStatus Status { set; get; }
        public int OrderDetailId { set; get; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
