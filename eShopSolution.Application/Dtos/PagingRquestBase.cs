using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class PagingRquestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
