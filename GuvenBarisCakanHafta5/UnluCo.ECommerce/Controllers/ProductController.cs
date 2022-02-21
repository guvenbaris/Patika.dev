using System.Net;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using UnluCo.ECommerce.Application.ProductOperations.Command.CreateProduct;
using UnluCo.ECommerce.Application.ProductOperations.Command.DeleteProduct;
using UnluCo.ECommerce.Application.ProductOperations.Command.UpdatePatchStatement;
using UnluCo.ECommerce.Application.ProductOperations.Command.UpdateProduct;
using UnluCo.ECommerce.Application.ProductOperations.Queries.GetProductDetail;
using UnluCo.ECommerce.Application.ProductOperations.Queries.GetProducts;
using UnluCo.ECommerce.Application.ProductOperations.Queries.GetProductsByCategory;
using UnluCo.ECommerce.Application.ProductOperations.Queries.GetProductsFilter;
using UnluCo.ECommerce.DbOperations;
using UnluCo.ECommerce.Entities;


namespace UnluCo.ECommerce.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;

        public ProductController(IMapper mapper, IProductRepository productRepository, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }

        //Bütün Productları listele
        //[Authorize(Roles = "Member")]
        //Redis ile Distributed Cache uygulanmıştır.
        [HttpGet]
        public   IActionResult GetAll()
        {
            GetProductsQuery query = new GetProductsQuery(_mapper, _productRepository,_distributedCache);
            var result = query.Handle();
            return Ok(result);

        }

        //ResponseCache kullanılmıştır.
        [HttpGet("{id}")]
        [ResponseCache(Duration = 60,Location = ResponseCacheLocation.Any)]
        public IActionResult Get(int id)
        {
            GetProductDetailQuery query = new(_mapper, _productRepository,_memoryCache)
            {
                ProductId = id
            };
            //GetProductDetailQueryValidator validator = new GetProductDetailQueryValidator();
            //validator.Validate(query);
            return Ok(query.Handle());
        }

        // Category id ye göre cash leme yapılmıştır. Kullanıcının hangi kategoriyi seçtiği tutulmak istenmiştir
        //Settings olarak.
        [HttpGet("categoryid/{id}")]
        public IActionResult GetProductByCategoryId(int id)
        {
            GetProductsByCategoryQuery query = new GetProductsByCategoryQuery(_mapper, _productRepository,_memoryCache);
            query.CategoryId = id;
            var result = query.Handle();
            return Ok(result);
        }

        //Yeni Bir Product Oluşturmak için.
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult Add([FromBody] CreateProductModel product)
        {

            CreateProductCommand command = new CreateProductCommand(_mapper, _productRepository);
            command.Model = product;

            CreateProductCommandValidator validator = new CreateProductCommandValidator();

            validator.ValidateAndThrow(command);

            command.Handle();

            return StatusCode((int)HttpStatusCode.Created);
        }

        //Product Update işlemi için
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, [FromBody] UpdateProductModel product)
        {

            UpdateProductCommand command = new UpdateProductCommand(_mapper, _productRepository);
            command.Model = product;
            command.ProductId = id;
            UpdateProductCommandValidator validator = new UpdateProductCommandValidator();

            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();

        }
        //Product'ın Statement ını update etmek için
        [HttpPatch("{id}")]
        [Authorize("Admin")]
        public IActionResult UpdateStatement(int id, [FromBody] bool statement)
        {

            UpdatePatchCommand command = new(_productRepository)
            {
                ProductId = id,
                Statement = statement
            };
            command.Handle();
            return Ok();
        }

        //Product'ı silmek için
        [HttpDelete("{id}")]
        [Authorize("Admin")]
        public IActionResult Delete(int id)
        {

            DeleteProductCommand command = new DeleteProductCommand(_productRepository);
            command.ProductId = id;
            command.Handle();
            return Ok();

        }

        //[ResponseCache(Duration = 60,Location =ResponseCacheLocation.Any,VaryByQueryKeys = new[] { "search"})]
        [HttpGet("query")]
        public IActionResult GetProducts([FromQuery] QueryParams queryParams)
        {

            GetProductsFilterQuery filterQuery = new(_mapper, _distributedCache, _productRepository)
                {
                    Params = queryParams
                };

            return Ok(filterQuery.Handle());
        }
    }
}
