using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
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
        public AccountController(ISqlSugarClient sqlSugarClient, ILogger<AccountController> logger)
        {
            _sqlSugarClient = sqlSugarClient;
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string userName, string passWord, string returl)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(type:ClaimTypes.Name,value:userName),
                new Claim("PassWord",passWord)
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
