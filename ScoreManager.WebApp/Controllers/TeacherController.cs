using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using ScoreManager.Model.ViewParameters;
using ScoreManager.ServiceInterface;
using ScoreManager.WebApp.Models;

namespace ScoreManager.WebApp.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IActionService _actionService;
        public TeacherController(IRoleService roleService, IActionService actionService)
        {
            _roleService = roleService;
            _actionService = actionService;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region 角色管理
        /// <summary>
        /// 教师角色列表
        /// </summary>
        /// <returns></returns>
        public IActionResult RoleList()
        {
            var data = _roleService.QueryWithAction(r => r.ActionList, r => true);
            return View(data);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <returns></returns>
        public IActionResult AddRole()
        {
            return View();
        }
        #endregion


        #region 权限管理
        /// <summary>
        /// 权限列表
        /// </summary>
        /// <returns></returns>
        public IActionResult ActionList()
        {
           var data=  _actionService.Query();
            return View(data);
        }
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <returns></returns>
        public IActionResult AddAction()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAction(AddActionParameter addActionParameter)
        {
            ApiResult result = new ApiResult();
            string msg;
            bool isSuccess= _actionService.AddAction(addActionParameter,out msg);
            if (isSuccess) 
            {
                result.Code = 0;
            }
            else
            {
                result.Code = -1;
                result.Message = msg;
            }

            return Json(result);
        }
        /// <summary>
        /// 启动 或禁用权限
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EnableOrDisAbledAction(int id,string status)
        {
            ApiResult result = new ApiResult();
            EDU_ACTION action = _actionService.QueryById(id);
            action.ISENABLE = status;
            _actionService.Update(action);
            return Json(result);
        }
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DelAction(int id)
        {
            ApiResult result = new ApiResult();
            bool res= _actionService.DeleteById(id);
            if (res) result.Code = 0; 
            else
            {
                result.Code = -1;
                result.Message = "删除失败";
            }
            return Json(result);
        }
        #endregion
    }
}
