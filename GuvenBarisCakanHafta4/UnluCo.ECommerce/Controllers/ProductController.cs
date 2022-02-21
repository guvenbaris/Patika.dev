using System.Net;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using UnluCo.ECommerce.Application.ProductOperations.Command.CreateProduct;
using UnluCo.ECommerce.Application.ProductOperations.Command.DeleteProduct;
using UnluCo.ECommerce.Application.ProductOperations.Command.UpdatePatchStatement;
using UnluCo.ECommerce.Application.ProductOperations.Command.UpdateProduct;
using UnluCo.ECommerce.Application.ProductOperations.Queries.GetProductDetail;
using UnluCo.ECommerce.Application.ProductOperations.Queries.GetProducts;
using UnluCo.ECommerce.Application.ProductOperations.Queries.GetProductsByCategory;
using UnluCo.ECommerce.DbOperations;


namespace UnluCo.ECommerce.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductController(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        //Bütün Productları listele
        [Authorize(Roles = "Member")]
        [HttpGet]
        public IActionResult GetAll()
        {
            GetProductsQuery query = new GetProductsQuery(_mapper, _productRepository);

            var result = query.Handle();

            return Ok(result);
        }
        //ProductId ye göre ürünü getirmek için
        [Authorize(Roles = "Member")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            GetProductDetailQuery query = new GetProductDetailQuery(_mapper, _productRepository);
            query.ProductId = id;
            //GetProductDetailQueryValidator validator = new GetProductDetailQueryValidator();
            //validator.Validate(query);
            return Ok(query.Handle());
        }

        //CategoryId ye göre ürünleri getirmek için 
        [Authorize(Roles = "Member")]
        [HttpGet("categoryid/{id}")]
        public IActionResult GetProductByCategoryId(int id)
        {
            GetProductsByCategoryQuery query = new GetProductsByCategoryQuery(_mapper, _productRepository);
            query.CategoryId = id;
            return Ok(query.Handle());
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

            UpdatePatchCommand command = new UpdatePatchCommand(_productRepository);
            command.ProductId = id;
            command.Statement = statement;
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
    }
}
