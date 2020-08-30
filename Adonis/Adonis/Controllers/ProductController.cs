using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adonis.Helpers;
using Adonis.Models.Entities;
using Adonis.Services.Interface;
using Adonis.ViewModels.Pagination;
using Adonis.ViewModels.Request;
using Adonis.ViewModels.Response;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adonis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public ProductController(IProductService productService, 
            IMapper mapper, 
            IUriService uriService)
        {
            _productService = productService;
            _mapper = mapper;
            _uriService = uriService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProduct();
            //aaaa
            return Ok(products);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]PaginationQuery paginationQuary)
        {
            var products = await _productService.GetAllProduct();

            var result = _mapper.Map<List<ProductResponse>>(products);

            if (paginationQuary == null || paginationQuary.PageNumber < 1 || paginationQuary.PageSize < 1)
            {
                return Ok(new Paged<ProductResponse>(result));
            }
            var paginationResponse = PaginationHelper.CreatePaginationResponse(_uriService, paginationQuary, result);
            return Ok(paginationResponse);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody]ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product()
            {
                Name = request.Name,
                Price = request.Price
            };

            var created = await _productService.CreateProduct(product);

            if (!created)
            {
                return BadRequest("Can not create product!");
            }

            return Ok(created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var product = await _productService.GetById(id);

            if (product is null)
            {
                return NotFound("Id is not match!");
            }

            var result = new ProductResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute]int id, [FromBody]ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productService.GetById(id);

            if (product is null)
            {
                return NotFound("ProductId can't find!");
            }

            product.Name = request.Name;
            product.Price = request.Price;

            var updated = await _productService.UpdateProduct(product);

            if (!updated)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(updated);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]int id)
        {
            var deleted = await _productService.DeleteProduct(id);
            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }

    }
}