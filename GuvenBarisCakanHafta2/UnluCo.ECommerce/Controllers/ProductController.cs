using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FluentValidation;
using UnluCo.ECommerce.Application.ProductOperations.Command.CreateProduct;
using UnluCo.ECommerce.Application.ProductOperations.Command.DeleteProduct;
using UnluCo.ECommerce.Application.ProductOperations.Command.UpdatePatchStatement;
using UnluCo.ECommerce.Application.ProductOperations.Command.UpdateProduct;
using UnluCo.ECommerce.Application.ProductOperations.Queries.GetProductDetail;
using UnluCo.ECommerce.Application.ProductOperations.Queries.GetProducts;
using UnluCo.ECommerce.Application.ProductOperations.Queries.GetProductsByCategory;
using UnluCo.ECommerce.Services.Business;


namespace UnluCo.ECommerce.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        //Bütün Productları listele
        [HttpGet]
        public IActionResult GetAll()
        {
            GetProductsQuery query = new GetProductsQuery(_mapper);

            var result = query.Handle();

            return Ok(result);
        }
        //ProductId ye göre ürünü getirmek için 
        [HttpGet("{id}")]
        public IActionResult Get(int id,int sayi2)
        {
            GetProductDetailQuery query = new GetProductDetailQuery(_mapper);
            query.ProductId = id;
            //GetProductDetailQueryValidator validator = new GetProductDetailQueryValidator();
            //validator.Validate(query);
            return Ok(query.Handle());

        }
        //CategoryId ye göre ürünleri getirmek için 
        [HttpGet("categoryid/{id}")]
        public IActionResult GetProductByCategoryId(int id)
        {
            GetProductsByCategoryQuery query = new GetProductsByCategoryQuery(_mapper);
            query.CategoryId = id;
            return Ok(query.Handle());
        }

        //Yeni Bir Product Oluşturmak için.
        [HttpPost]
        public IActionResult Add([FromBody] CreateProductModel product)
        {

            CreateProductCommand command = new CreateProductCommand(_mapper);
            command.Model = product;

            CreateProductCommandValidator validator = new CreateProductCommandValidator();

            validator.ValidateAndThrow(command);

            command.Handle();

            return StatusCode((int)HttpStatusCode.Created);
        }
        //Product Update işlemi için

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateProductModel product)
        {

            UpdateProductCommand command = new UpdateProductCommand(_mapper);
            command.Model = product;
            command.ProductId = id;

            UpdateProductCommandValidator validator = new UpdateProductCommandValidator();

            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();

        }
        //Product'ın Statement ını update etmek için

        [HttpPatch("{id}")]
        public IActionResult UpdateStatement(int id, [FromBody] bool statement)
        {

            UpdatePatchCommand command = new UpdatePatchCommand();
            command.ProductId = id;
            command.Statement = statement;
            command.Handle();
            return Ok();
        }

        //Product'ı silmek için
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            DeleteProductCommand command = new DeleteProductCommand();
            command.ProductId = id;
            command.Handle();
            return Ok();

        }
    }
}
