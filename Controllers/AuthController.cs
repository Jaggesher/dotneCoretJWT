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

namespace dotnetCoreJWT.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtIssuerOptions _jwtIssuerOptions;
        private readonly IJwtFactoryService _jwtFactory;

        public AuthController(UserManager<ApplicationUser> userManager, IJwtFactoryService jwtFactory,
         IOptions<JwtIssuerOptions> jwtIssuerOptions)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtIssuerOptions = jwtIssuerOptions.Value;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(_userManager);
        }
    }
}