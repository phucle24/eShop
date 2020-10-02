using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Manage;
using eShopSolution.Application.Dtos;
using eShopSolution.Data.EF;
using eShopSolution.Data.Enitities;
using eShopSolution.Utilities.Exeptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly eShopDbContext _context;
        private Exception eShopException;

        public ManageProductService(eShopDbContext context)
        {
            _context = context;
        }

        public async Task AddViewCount(int producId)
        {
            var product = await _context.Products.FindAsync(producId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();

        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>() 
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        SeoDescription =request.SeoDescription,
                        SeoTile = request.SeoTile,
                        Details = request.Details,
                        LanguageId = request.LanguageId
                    }
                }
            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int producId)
        {
            var product = await _context.Products.FindAsync(producId);
            if (product == null) throw new eShopException($"Cant not find a product{producId}");
            _context.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            //1 . Join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCaregories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p,pic, pt};
            // 2. fillter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            }
            if(request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }
            // 3.Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                  Id = x.p.Id,
                  Name = x.pt.Name,
                  DateCreated = x.p.DateCreated,
                  Description = x.pt.Description,
                  Details = x.pt.Details,
                  LanguageId = x.pt.LanguageId,
                  OriginalPrice = x.p.OriginalPrice,
                  Price = x.p.Price,
                  SeoDescription = x.pt.SeoDescription,
                  SeoTile = x.pt.SeoTile,
                  Stock = x.p.Stock,
                  ViewCount = x.p.ViewCount
                }).ToListAsync();

            // 4.Select and projection
            var pagedReult = new PageResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data,
            };
            return pagedReult;
         }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id
            && x.LanguageId == request.LanguageId); 
            if (product == null) throw new eShopException($"Can not find product {request.Id}");

            productTranslations.Name = request.Name;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTile = request.SeoTile;
            productTranslations.Description = request.Description;
            productTranslations.Details = request.Details;
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int producId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(producId);
            if (product == null) throw new eShopException($"Can not find product {producId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateStock(int producId, int addedQuanity)
        {
            var product = await _context.Products.FindAsync(producId);
            if (product == null) throw new eShopException($"Can not find product {producId}");
            product.Price += addedQuanity;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
