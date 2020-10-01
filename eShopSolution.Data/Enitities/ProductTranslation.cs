using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Enitities
{
    public class ProductTranslation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTile { get; set; }
        public int ProductId { get; set; } 
        public Language Language { get; set; }

        public Product Product { get; set; }
    }
}
