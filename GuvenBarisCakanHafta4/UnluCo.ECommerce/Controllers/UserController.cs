using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using UnluCo.ECommerce.Authentication;
using UnluCo.ECommerce.Authorization;
using UnluCo.ECommerce.Entities;


namespace UnluCo.ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenGenarator _tokenGenarator;
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenGenarator tokenGenarator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenarator = tokenGenarator;
        }
        [HttpPost("login")]
        public  async Task<IActionResult> Login([FromBody] UserLogin user)
        {
            var userFind = _userManager.FindByEmailAsync(user.Email).Result;
            if (userFind is null) throw new BadHttpRequestException("User didn't found");

            var result = await _userManager.CheckPasswordAsync(userFind, user.Password);

            if (!result) return BadRequest("Login is denied");
            var userRoles =  await _userManager.GetRolesAsync(userFind);
            return Ok(_tokenGenarator.CreateToken(userFind,userRoles).AccessToken);

        }
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] UserSignIn user)
        {
            if (ModelState.IsValid)
            {
                var appUser = new AppUser
                {
                    UserName =user.UserName,
                    Email = user.Email,

                };
                var emailCheckUser =  await _userManager.FindByEmailAsync(user.Email);

                if (emailCheckUser is not null) throw new BadHttpRequestException("Email already exists");

                var result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser,"Member");
                    await _signInManager.SignInAsync(appUser, false);
                    return Ok("Sign In Success");
                }
            }
            return BadRequest("Check UserName,Email or Password");
        }
    }
}


