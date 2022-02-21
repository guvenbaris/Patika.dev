using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpPut("retractoffer/{offerId}")]
        public IActionResult RetractTheOffer(int offerId)
        {
            _productService.RetractTheOffer(offerId);
            return Ok();
        }

        [HttpPut("sellproduct{id}")]
        public IActionResult SellProduct(int id, double price)
        {
            //var userId = User.FindFirstValue(ClaimTypes.Name);
            var userId = "514ee1a1-f24b-40bf-b0d9-c5da6357c151";
            _productService.SellProduct(id, userId, price);
            return Ok();
        }

        [HttpPut("productisofferable/{id}")]
        public IActionResult UpdateIsOfferable(int id)
        {
            _productService.UpdateIsOfferable(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel product)
        {
            //userId get FromBody
            //var userId = User.FindFirstValue(ClaimTypes.Name);
            var userId = "514ee1a1-f24b-40bf-b0d9-c5da6357c151";
            _productService.Create(product,userId);
            return Ok();
        }
    }
}
