using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public bool isDefault { get; set; }
        public DateTime DateCreated { get; set; }
        public int SortOrder { get; set; }
    }
}
