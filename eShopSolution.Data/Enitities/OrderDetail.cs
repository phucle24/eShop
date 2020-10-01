using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Enitities
{
    public class OrderDetail
    {
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quanity { set; get; }
        public decimal Price { set; get; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
