using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using ScoreManager.Model.ViewParameters;
using ScoreManager.ServiceInterface;
using ScoreManager.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

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
            //查找所有权限
            var actions = _actionService.Query().Where(c => c.ISENABLE == "1");
            return View(actions);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddRole(AddRoleParameter addRoleParameter)
        {
            ApiResult result = new ApiResult();
            string msg;
            EDU_ROLE roleWithActions = new EDU_ROLE();
            roleWithActions.NAME = addRoleParameter.RoleName;
            roleWithActions.DESCRIPTION = addRoleParameter.RoleDescription;
            roleWithActions.ISENABLE = addRoleParameter.IsEnable;
            roleWithActions.ActionList = new List<EDU_ACTION>();
            if (addRoleParameter.SelectActions!=null)
            {
                foreach (var item in addRoleParameter.SelectActions)
                {
                    EDU_ACTION temAction = new EDU_ACTION() { ID = item };
                    roleWithActions.ActionList.Add(temAction);
                }
            }
            
            
            bool isSuccess = _roleService.AddWithActions(roleWithActions, out msg);
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
        /// 启动 或禁用角色
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EnableOrDisAbledRole(int id, string status)
        {
            ApiResult result = new ApiResult();
            EDU_ROLE role = _roleService.QueryById(id);
            role.ISENABLE = status;
            _roleService.Update(role);
            return Json(result);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DelRole(int id)
        {
            ApiResult result = new ApiResult();
            bool res = _roleService.DeleteRoleWithRelation(id);
            if (res) result.Code = 0;
            else
            {
                result.Code = -1;
                result.Message = "删除失败";
            }
            return Json(result);
        }
        /// <summary>
        /// 编辑角色页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult EditRole(int id)
        {
            var role= _roleService.QueryWithAction(r => r.ActionList, r => r.ID==id).First();
            ViewData["Actions"]= _actionService.Query().Where(c => c.ISENABLE == "1");
            return View(role);
        }

        /// <summary>
        /// 编辑角色页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditRole(int RoleId, AddRoleParameter addRoleParameter)
        {
            ApiResult result = new ApiResult();
            string msg;
            EDU_ROLE roleWithActions= _roleService.QueryWithAction(r => r.ActionList, r => r.ID == RoleId).First();
            roleWithActions.DESCRIPTION = addRoleParameter.RoleDescription;
            roleWithActions.ActionList?.Clear();
            if (addRoleParameter.SelectActions!=null)
            {
                roleWithActions.ActionList = new List<EDU_ACTION>();
                foreach (var item in addRoleParameter.SelectActions)
                {
                    EDU_ACTION temAction = new EDU_ACTION() { ID = item };
                    roleWithActions.ActionList.Add(temAction);
                }
            }
            

            bool isSuccess = _roleService.UpdateWithActions(roleWithActions, out msg);
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
