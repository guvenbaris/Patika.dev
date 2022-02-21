using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.ECommerce.Application.UserOperations.Command;
using UnluCo.ECommerce.Entities;

namespace UnluCo.ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        //Kullanıcı giriş yaptığında kullanıcının girdiği userName ve password bilgisini alıp 
        //kontrol etmek için yazılan attribute ve Method
        [VerifyUser]
        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            return Ok("Hope you have a good time on our website.");

        }
    }
}

