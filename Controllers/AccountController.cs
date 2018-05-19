using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetCoreJWT.Data;
using dotnetCoreJWT.Models;
using Microsoft.AspNetCore.Identity;
using dotnetCoreJWT.ViewModels;
using dotnetCoreJWT.Helpers;

namespace dotnetCoreJWT.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _appDbCOntex;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(ApplicationDbContext applicationDb,
         UserManager<ApplicationUser> userManager)
        {
            _appDbCOntex = applicationDb;
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Post([FromBody] RegistrationViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return BadRequest(Errors.AddErrorsToModelState(result, ModelState));

            return new ObjectResult(new { Message = "Account Created" });

        }

    }
}