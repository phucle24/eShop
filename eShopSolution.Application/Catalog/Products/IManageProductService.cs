using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Manage;
using eShopSolution.Application.Dtos;
using System;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int producId);
        Task<bool> UpdatePrice(int producId,decimal newPrice);
        Task<bool> UpdateStock(int producId,int addedQuanity);
        Task AddViewCount(int producId);

        Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
    }
}
