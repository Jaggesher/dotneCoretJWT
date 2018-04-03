using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetCoreJWT.Data;
using dotnetCoreJWT.Models;
using Microsoft.AspNetCore.Identity;
using dotnetCoreJWT.ViewModels;

namespace dotnetCoreJWT.Controllers
{
    [Route("api/[Controller]/[action]")]
    public class AccoutController : Controller
    {
        private readonly ApplicationDbContext _appDbCOntex;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccoutController(ApplicationDbContext applicationDb,
         UserManager<ApplicationUser> userManager)
        {
            _appDbCOntex = applicationDb;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user,model.Password);
            return new ObjectResult(result);

        }



    }
}