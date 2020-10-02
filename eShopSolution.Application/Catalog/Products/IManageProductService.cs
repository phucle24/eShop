﻿
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int producId);
        Task<bool> UpdatePrice(int producId, decimal newPrice);
        Task<bool> UpdateStock(int producId, int addedQuanity);
        Task AddViewCount(int producId);

        Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
        Task<int> AddImages(int productId, List<IFormFile> files);
        Task<int> UpdateImages(int imageId, string caption, bool isDefault);
        Task<int> RemoveImages(int imageId);
        Task<List<ProductImageViewModel>> GetListImage(int productId);
    }
}
