using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;


namespace eShopSolution.AdminApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PageResultBase result)
        {
            return await Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
