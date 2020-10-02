using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Enitities;
using eShopSolution.Utilities.Exeptions;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly eShopDbContext _context;
        private readonly FileStorageService _storageService;
        public ManageProductService(eShopDbContext context, FileStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public Task<int> AddImages(int productId, List<IFormFile> files)
        {
            throw new NotImplementedException();
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
            //Save Image

            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>() {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        isDefault =true,
                        SortOrder = 1,
                    }
                };
            }
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new eShopException($"Cant not find a product{productId}");
            var images = _context.ProductImages.Where(i => i.ProductId == productId);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }
            _context.Products.Remove(product);   
            return await _context.SaveChangesAsync();
        }

        public async Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {   
            //1 . Join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCaregories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pic, pt };
            // 2. fillter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            }
            if (request.CategoryIds.Count > 0)
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

        public Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveImages(int imageId)
        {
            throw new NotImplementedException();
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
            //Save Image

            if (request.ThumbnailImage != null)
            {
                var thumnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.isDefault == true && i.ProductId == request.Id);
                if (thumnailImage != null)
                {
                    thumnailImage.FileSize = request.ThumbnailImage.Length;
                    thumnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumnailImage);
                };
            }
            return await _context.SaveChangesAsync();
        }

        public Task<int> UpdateImages(int imageId, string caption, bool isDefault)
        {
            throw new NotImplementedException();
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

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
