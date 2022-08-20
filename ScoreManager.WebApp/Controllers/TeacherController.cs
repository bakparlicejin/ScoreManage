using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using ScoreManager.Model.Enum;
using ScoreManager.Model.ViewParameters;
using ScoreManager.ServiceInterface;
using ScoreManager.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreManager.WebApp.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IActionService _actionService;
        private readonly ITeacherService _teacherService;
        private readonly ISubjectService _subjectService;
        private readonly IUserService _userService;
        public TeacherController(IRoleService roleService, IActionService actionService, ITeacherService teacherService, ISubjectService subjectService, IUserService userService)
        {
            _roleService = roleService;
            _actionService = actionService;
            _teacherService = teacherService;
            _subjectService = subjectService;
            _userService = userService;
        }
        #region 角色管理
        /// <summary>
        /// 教师角色列表
        /// </summary>
        /// <returns></returns>
        public IActionResult RoleList()
        {
            var data = _roleService.QueryWithAction(r => r.Actions, r => true);
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
            roleWithActions.Actions = new List<EDU_ACTION>();
            if (addRoleParameter.SelectActions!=null)
            {
                foreach (var item in addRoleParameter.SelectActions)
                {
                    EDU_ACTION temAction = new EDU_ACTION() { ID = item };
                    roleWithActions.Actions.Add(temAction);
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
            var role= _roleService.QueryWithAction(r => r.Actions, r => r.ID==id).First();
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
            EDU_ROLE roleWithActions= _roleService.QueryWithAction(r => r.Actions, r => r.ID == RoleId).First();
            roleWithActions.DESCRIPTION = addRoleParameter.RoleDescription;
            roleWithActions.Actions?.Clear();
            if (addRoleParameter.SelectActions!=null)
            {
                roleWithActions.Actions = new List<EDU_ACTION>();
                foreach (var item in addRoleParameter.SelectActions)
                {
                    EDU_ACTION temAction = new EDU_ACTION() { ID = item };
                    roleWithActions.Actions.Add(temAction);
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

        #region 教师管理
        /// <summary>
        /// 教师列表
        /// </summary>
        /// <returns></returns>
        public IActionResult TeacherList()
        {
           
            return View();
        }
        /// <summary>
        /// 查询分页信息
        /// </summary>
        /// <param name="KeyWords">关键词</param>
        /// <returns></returns>
        public IActionResult TeacherListPageInfo(TeacherListParameter parameter)
        {
           int totalCount=  _teacherService.CountByKeyWords(parameter);
            return Json(new { TotalCount = totalCount, PageSize = parameter.PageSize });
        }
        /// <summary>
        /// 查询列表详情
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult TeacherListDetail(TeacherListParameter parameter)
        {
            //查询教师列表数据
            int totalCount = 0;
            var list = _teacherService.GetTeacherListWithUserAndRole(parameter, ref totalCount);
            ViewData["TotalCount"] = totalCount;
            ViewData["PageSize"] = parameter.PageSize;
            ViewData["PageIndex"] = parameter.PageIndex;
            return PartialView("TeacherListDetail",list);
        }
        /// <summary>
        /// 添加老师
        /// </summary>
        /// <returns></returns>
        public IActionResult AddTeacher()
        {
            //查询学科信息
            var subjectList = _subjectService.Query();
            ViewBag.Subjects = subjectList;
            //查询角色信息
            var roles= _roleService.Query().Where(c => c.ISENABLE == "1")?.ToList();
            ViewBag.Roles = roles;
            return View();
        }
        [HttpPost]
        public IActionResult AddTeacher(AddTeacherParameter parameters)
        {
            ApiResult apiResult = new ApiResult() { Code = 0 };
            try
            {
                //先查
                bool isExist = _userService.IsExist(parameters.UserName);
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

                    //2. 增加老师
                    
                    EDU_TEACHER teacher = new EDU_TEACHER();
                    teacher.USERID = userId;
                    teacher.NAME = parameters.RealName;
                    teacher.PHONE_NUMBER = parameters.Phone;
                    teacher.EMAIL_ADDRESS = parameters.Email;
                    teacher.SUBJECTID = parameters.Subject;
                    teacher.Roles = new List<EDU_ROLE>();
                    if (parameters.SelectRoles != null)
                    {
                        foreach (var item in parameters.SelectRoles)
                        {
                            EDU_ROLE temAction = new EDU_ROLE() { ID = item };
                            teacher.Roles.Add(temAction);
                        }
                    }
                    c.InsertNav<EDU_TEACHER>(teacher).Include(x => x.Roles).ExecuteCommand();
                });
            }
            catch (Exception ex)
            {
                apiResult.Message = "创建教师失败";
                apiResult.Code = -1;
            }
            return Json(apiResult);
        }
        /// <summary>
        /// 编辑老师
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        public IActionResult EditTeacher(int id)
        {
            EDU_TEACHER teacher= _teacherService.GetFullInfoById(id);
            //查询角色信息
            var roles = _roleService.Query().Where(c => c.ISENABLE == "1")?.ToList();
            ViewBag.Roles = roles;
            return View(teacher);
        }
        [HttpPost]
        public IActionResult EditTeacher(int id, AddTeacherParameter parameters)
        {
            ApiResult result = new ApiResult();
            EDU_TEACHER teacher = _teacherService.GetFullInfoById(id);
            teacher.PHONE_NUMBER = parameters.Phone;
            teacher.NAME = parameters.RealName;
            teacher.EMAIL_ADDRESS = parameters.Email;
            teacher.Roles?.Clear();

            if (parameters.SelectRoles != null)
            {
                teacher.Roles = new List<EDU_ROLE>();
                foreach (var item in parameters.SelectRoles)
                {
                    EDU_ROLE temAction = new EDU_ROLE() { ID = item };
                    teacher.Roles.Add(temAction);
                }
            }
            teacher.User.PASSWORD = parameters.Pass;
            string msg;
            bool isSuccess= _teacherService.UpdateFullInfo(teacher, out msg);
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
        [HttpPost]
        public IActionResult DeleteFullInfo(int id)
        {
            string msg;
            ApiResult result = new ApiResult();
            bool isSuccess= _teacherService.DeleteFullInfo(id, out msg);
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
    }
}
