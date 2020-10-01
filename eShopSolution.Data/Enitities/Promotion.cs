using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Enitities
{
    public class Promotion
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool ApplyForAll { get; set; }
        public int? DiscountPercent { set; get; }
        public decimal? DiscountAmount { get; set; }
        public string ProductIds { get; set; }
        public string ProducCategoryIds { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
    }
}
