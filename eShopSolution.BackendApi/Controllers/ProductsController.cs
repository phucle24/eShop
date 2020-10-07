using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;
        public ProductsController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        // http://localhost:port/products?pageIndex=1&pageSize=10&CategoryId=1
        [HttpGet("{languageId}")]
        public async Task<ActionResult> GetAllPaging(string languageId,[FromQuery]GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCategoryId(languageId,request);
            return Ok(products);
        }

        // http://localhost:port/product/1/vi-VN
        [HttpGet("{productId}/{languageId}")]
        public async Task<ActionResult> GetById(int productId, string languageId)
        {
            var product = await _manageProductService.GetById(productId, languageId);
            if (product == null) return BadRequest("Can not find product");
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm]ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _manageProductService.Create(request);
            if (productId == 0) return BadRequest();

            var product = await _manageProductService.GetById(productId, request.LanguageId);

            //return Created(nameof(GetById),product);
            return CreatedAtAction(nameof(GetById), new { id =productId },product);
        }

        [HttpPut("{productId}")]
        public async Task<ActionResult> Update([FromForm]ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _manageProductService.Update(request);
            if (affectedResult == 0) return BadRequest();
            return Ok(affectedResult);
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> Delete(int productId)
        {
            var affectedResult = await _manageProductService.Delete(productId);
            if (affectedResult == 0) return BadRequest();
            return Ok(affectedResult);
        }

        [HttpPatch("{productId}/{newPrice}")]
        public async Task<ActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var isSuccesful = await _manageProductService.UpdatePrice(productId, newPrice);
            if (isSuccesful == true) return Ok();
            return BadRequest();
        }

        // Images

        [HttpPost("{productId}/images")]
        public async Task<ActionResult> CreateImage(int productId,[FromForm]ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _manageProductService.AddImage(productId, request);
            if (imageId == 0) return BadRequest();

            var image = await _manageProductService.GetImageById(imageId);

            //return Created(nameof(GetById),product);
            return CreatedAtAction(nameof(GetById), new { id = imageId }, image);
        }


        [HttpPut("{productId}/images/{imageId}")]
        public async Task<ActionResult> UpdateImage(int imageId, [FromForm]ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductService.UpdateImage(imageId, request);
            if (result == 0) return BadRequest();
            return Ok();
        }

        // http://localhost:port/product/1/vi-VN
        [HttpGet("{productId}/images/{imageId}")]
        public async Task<ActionResult> GetImageById(int productId, int imageId)
        {
            var image = await _manageProductService.GetImageById(imageId);
            if (image == null) return BadRequest("Can not find image");
            return Ok(image);
        }
    }
}