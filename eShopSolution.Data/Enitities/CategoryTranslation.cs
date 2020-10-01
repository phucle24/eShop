﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Enitities
{
    public class CategoryTranslation
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string SeoDesciption { get; set; }
        public string SeoTile { get; set; }
        public string SeoAlias { get; set; }
        public string LanguageId { get; set; }

        public Language Language { get; set; }
        public Category Category { get; set; }

    }
}
