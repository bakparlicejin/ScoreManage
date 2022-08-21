using Microsoft.AspNetCore.Mvc;
using Models;
using ScoreManager.Model.ViewParameters;
using ScoreManager.ServiceInterface;
using ScoreManager.WebApp.Models;
using System;
using System.Collections.Generic;

namespace ScoreManager.WebApp.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassService _classService;
        private readonly ITeacherService _teacherService;
        public ClassController(IClassService classService, ITeacherService teacherService)
        {
            _classService = classService;
            _teacherService = teacherService;
        }
        public IActionResult ClassList()
        {
            List<EDU_CLASS> data=  _classService.GetAllClassInfo();
            return View(data);
        }
        /// <summary>
        /// 增加班级
        /// </summary>
        /// <returns></returns>
        public IActionResult AddClass()
        {
            //查询老师带上角色
            List<EDU_TEACHER> teachers= _teacherService.GetTeacherListWithRole();
            ViewBag.Teachers = teachers;
            return View();
        }
        [HttpPost]
        public IActionResult AddClass(AddClassParameter parameter)
        {
            string msg;
            bool success = _classService.AddClass(parameter,out msg);
            if (success)
            {
                return Json(ApiResult.OK());
            }
            else
            {
                return Json(ApiResult.Error(msg));
            }
            
        }

        /// <summary>
        /// 启动 或禁用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EnableOrDisAbledClass(int id, string status)
        {
            ApiResult result = new ApiResult();
            EDU_CLASS cl = _classService.QueryById(id);
            cl.ISENABLE = status;
            _classService.Update(cl);
            return Json(result);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">班级id</param>
        /// <returns></returns>
        public IActionResult EditClass(int id)
        {
            List<EDU_TEACHER> teachers = _teacherService.GetTeacherListWithRole();
            ViewBag.Teachers = teachers;
            EDU_CLASS data= _classService.GetAllClassInfoByClassId(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditClass(UpdateClassParameter parameter)
        {
            string msg;
            bool success= _classService.UpdateTeacher(parameter, out msg);
            if (success)
            {
                return Json(ApiResult.OK());
            }
            else
            {
                return Json(ApiResult.Error(msg));
            }
        }
    }
}
