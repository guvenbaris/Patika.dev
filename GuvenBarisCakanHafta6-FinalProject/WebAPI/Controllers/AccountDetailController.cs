using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class AccountDetailController : ControllerBase
    {
        private readonly IAccountDetailService _accountDetailService;

        public AccountDetailController(IAccountDetailService accountDetailService)
        {
            _accountDetailService = accountDetailService;
        }

        [HttpGet("getuseroffers")]
        public IActionResult GetUserOffer()
        {
            //var userId = User.FindFirstValue(ClaimTypes.Name);

            var userId = "514ee1a1-f24b-40bf-b0d9-c5da6357c151";

            return Ok(_accountDetailService.GetUserOffers(userId));
        }

        [HttpGet("getuserproductoffer")]
        public IActionResult GetOffersOnUserProducts()
        {
            //var userId = User.FindFirstValue(ClaimTypes.Name);
            var userId = "514ee1a1-f24b-40bf-b0d9-c5da6357c151";
            return Ok(_accountDetailService.GetOffersOnUserProducts(userId));

        }
    }
}
