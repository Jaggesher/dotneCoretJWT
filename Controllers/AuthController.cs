using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dotnetCoreJWT.Data;
using dotnetCoreJWT.Models;
using dotnetCoreJWT.ViewModels;
using Microsoft.AspNetCore.Identity;
using dotnetCoreJWT.Services;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace dotnetCoreJWT.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtFactoryService _jwtFactory;

        public AuthController(UserManager<ApplicationUser> userManager, IJwtFactoryService jwtFactory)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(_userManager);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]loginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null) return BadRequest("Ivalid User Name");

            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {

                var response = new
                    {
                        id = user.Id,
                        auth_token = await _jwtFactory.GenerateToken(user.UserName, user.Id)
                    };

                var jwt = JsonConvert.SerializeObject(response);
                return new OkObjectResult(jwt);
                
            }
            return BadRequest("Ivalid User Password");
        }
    }
}