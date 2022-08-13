using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using ScoreManager.Model.Enum;
using ScoreManager.Model.ViewParameters;
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
            if (user == null) return Json(ApiResult.Error("用户名或密码错误"));
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
            return Json(ApiResult.OK());
        }
        /// <summary>
        /// 注册页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Regist()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Regist(RegisterParameter parameters)
        {
            ApiResult apiResult = new ApiResult() { Code=0};
            try
            {
                //先查
               bool isExist=  _userService.IsExist(parameters.UserName);
                if (isExist)
                {
                    apiResult.Code = -1;
                    apiResult.Message = "用户名已被使用";
                    return Json(apiResult);
                }
                _userService.TransactionOperation(c =>
                {
                    
                    //1. 先增加用户
                    EDU_USER user = new EDU_USER()
                    {
                        USERNAME = parameters.UserName,
                        PASSWORD = parameters.Pass,
                        TYPE = parameters.UserType
                    };
                    int userId = c.Insertable<EDU_USER>(user).ExecuteReturnIdentity();

                    //2. 根据用户类型 增加学生或者老师
                    if (parameters.UserType == (short)UserType.Teacher)
                    {
                        EDU_TEACHER teacher = new EDU_TEACHER();
                        teacher.USERID = userId;
                        teacher.NAME = parameters.Name;
                        teacher.PHONE_NUMBER = parameters.Phone;
                        teacher.EMAIL_ADDRESS = parameters.Email;
                        c.Insertable(teacher).ExecuteCommand();
                    }
                    if (parameters.UserType == (short)UserType.Student)
                    {
                        EDU_STUDENT student = new EDU_STUDENT();
                        student.USERID = userId;
                        student.NAME = parameters.Name;
                        c.Insertable(student).ExecuteCommand();
                    }
                });
            }
            catch (Exception ex)
            {
                apiResult.Message = "创建用户失败";
                apiResult.Code = -1;
            }
           
            

            return Json(apiResult);
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
