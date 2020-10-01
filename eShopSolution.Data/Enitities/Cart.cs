using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Enitities
{
    public class Cart
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public int Quanity { set; get; }
        public decimal Price { set; get; }
        public Guid UserId { get; set; }
        public Product Product { get; set; }
        public DateTime DateTimeCreated { get; set; }
    }
}
