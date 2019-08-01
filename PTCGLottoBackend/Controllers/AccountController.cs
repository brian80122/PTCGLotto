using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PTCGLottoBackend.Models.Requests;
using PTCGLottoLibrary.Models.CodeFirsts;

namespace PTCGLottoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        [HttpPost, Route("Register")]
        public async Task<IdentityResult> Register(RegisterRequest request)
        {
            var createResult = await _userManager.CreateAsync(new User()
            {
                UserName = request.UserName,
                Email = request.Email
            }, request.PassWord);

            return createResult;
        }


        [HttpPost, Route("SignIn")]
        public async Task<Microsoft.AspNetCore.Identity.SignInResult> SignIn(SignInRequest request)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(request.UserName, request.PassWord, request.RememberMe, true);

            return signInResult;
        }
    }
}