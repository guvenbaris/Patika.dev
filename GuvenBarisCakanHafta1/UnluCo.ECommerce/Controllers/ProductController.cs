using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.ECommerce.Entities;

namespace UnluCo.ECommerce.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> ProductList = new List<Product>
        {
            new Product
            {
                ProductId = 1,
                ProductName = "Mouse",
                UnitPrice = 100,
                StockAmount = 50,
                ProductAddedTime = DateTime.Now,
                Statement = false,
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Klavye",
                UnitPrice = 200,
                StockAmount = 75,
                ProductAddedTime = DateTime.Now,
                Statement = true,
            },
            new Product
            {
                ProductId = 3,
                ProductName = "Computer",
                UnitPrice = 4000,
                StockAmount = 10,
                ProductAddedTime = new DateTime(2021,05,24),
                Statement = false,
            },
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ProductList);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById([FromQuery] int id)
        {
            var product = ProductList.SingleOrDefault(p => p.ProductId == id);
            if (product is null)
            {
                return BadRequest();
            }

            return Ok(product);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = ProductList.SingleOrDefault(p => p.ProductId == id);
            if (product is null)
            {
                return BadRequest();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            var productExist = ProductList.SingleOrDefault(p => p.ProductId == product.ProductId);
            if (productExist is not null)
            {
                return BadRequest();
            }

            ProductList.Add(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] Product product)
        {
            var productExist = ProductList.SingleOrDefault(p => p.ProductId == id);
            if (productExist is null)
            {
                return BadRequest();
            }

            productExist.ProductName = product.ProductName != default ? product.ProductName : productExist.ProductName;
            productExist.UnitPrice = product.UnitPrice != default ? product.UnitPrice : productExist.UnitPrice;
            productExist.StockAmount = product.StockAmount != default ? product.StockAmount : productExist.StockAmount;
            productExist.ProductAddedTime = product.ProductAddedTime != default ? product.ProductAddedTime : productExist.ProductAddedTime;
            productExist.Statement = product.Statement != default ? product.Statement : productExist.Statement;
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateStatement(int id, [FromBody] bool statement)
        {
            var productExist = ProductList.SingleOrDefault(p => p.ProductId == id);
            if (productExist is null)
            {
                return BadRequest();
            }

            productExist.Statement = statement;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productExist = ProductList.SingleOrDefault(p => p.ProductId == id);
            if (productExist is null)
            {
                return BadRequest();
            }

            ProductList.Remove(productExist);
            return Ok();
        }

        [HttpGet("pagenotfound")]
        public IActionResult PageNotFound()
        {
            return StatusCode(404);
        }
        [HttpGet("internalservererror")]
        public IActionResult InternalServerError()
        {
            return StatusCode(500);
        }
    }
}
