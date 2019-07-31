using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PTCGLottoLibrary.Models.CodeFirsts;

namespace PTCGLottoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private UserManager<User> _userManager;
        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }



        [HttpPost]
        public async Task<IdentityResult> Register()
        {
            var createResult = await _userManager.CreateAsync(new User()
            {
                UserName = "Brian",
                Email = "brian80122@gmail.com"
            }, "123456");

            return createResult;
        }
    }
}