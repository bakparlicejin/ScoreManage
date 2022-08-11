using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using ScoreManager.ServiceInterface;
using ScoreManager.WebApp.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ScoreManager.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ISqlSugarClient _sqlSugarClient;
        private readonly IUserService _userService;

        public AccountController(ISqlSugarClient sqlSugarClient, ILogger<AccountController> logger, IUserService userService)
        {
            _sqlSugarClient = sqlSugarClient;
            _logger = logger;
            _userService = userService;
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string userName, string passWord, string returl)
        {
            var user= _userService.GetUserByNameAndPass(userName, passWord);
            if (user == null) return Json(ApiResult<EDU_USER>.Error("用户名或密码错误"));
            List<Claim> claims = new List<Claim>()
            {
                new Claim(type:ClaimTypes.Name,value:user.USERNAME),
                new Claim("PassWord",user.PASSWORD)
            };
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "customer"));
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties()
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
            }).Wait();
            return base.Redirect("/Home/Index");
        }

        public IActionResult AddUser()
        {
            EDU_USER user = new EDU_USER()
            {
                USERNAME = "admin",
                PASSWORD = "admin123",
                TYPE = 0
            };
            int i = _sqlSugarClient.Insertable(user).ExecuteCommand();

            user = _sqlSugarClient.Queryable<EDU_USER>().First();
            return View(user);
        }
    }
}
