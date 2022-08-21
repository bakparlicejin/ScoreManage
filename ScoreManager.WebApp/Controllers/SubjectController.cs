using Microsoft.AspNetCore.Mvc;
using Models;
using ScoreManager.Model.Enum;
using ScoreManager.Model.ViewParameters;
using ScoreManager.ServiceInterface;
using ScoreManager.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ScoreManager.WebApp.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;
        public SubjectController(ISubjectService subjectService, ITeacherService teacherService)
        {
            _subjectService = subjectService;
            _teacherService = teacherService;
        }
        public IActionResult SubjectList()
        {
            var data= _subjectService.Query();
            return View(data);
        }
        /// <summary>
        /// 添加学科
        /// </summary>
        /// <returns></returns>

        public IActionResult AddSubject()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSubject(AddSubjectParameter addSubjectParameter)
        {
            ApiResult result = new ApiResult();
            string msg;
            bool isSuccess = _subjectService.AddSubject(addSubjectParameter, out msg);
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
        public IActionResult EnableOrDisAbledSubject(int id, string status)
        {
            ApiResult result = new ApiResult();
            EDU_SUBJECT subject = _subjectService.QueryById(id);
            subject.ISENABLE = status;
            _subjectService.Update(subject);
            return Json(result);
        }


        /// <summary>
        /// 删除学科
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DelSubject(int id)
        {
            ApiResult result = new ApiResult();
            bool res = _subjectService.DeleteById(id);
            if (res) result.Code = 0;
            else
            {
                result.Code = -1;
                result.Message = "删除失败";
            }
            return Json(result);
        }

        public IActionResult EditTeacher(int subjectId)
        {
            //查询当前学科下所有的老师 以及未分配学科的老师
            List<EDU_TEACHER> allEnableTeachers = _teacherService.Query().Where(c => c.ISDELETE == "1"&&(c.SUBJECTID==0||c.SUBJECTID==subjectId))?.ToList();
            //查询所有当前学科的老师
            List<EDU_TEACHER> currentSubjectTeachers = allEnableTeachers.Where(c=>c.SUBJECTID ==subjectId)?.ToList();

            ViewBag.AllEnableTeachers = allEnableTeachers;
            ViewBag.CurrentSubjectTeachers = currentSubjectTeachers;
            ViewBag.SubjectId = subjectId;
            return View();
        }
        /// <summary>
        /// 批量更新教师的学科
        /// </summary>
        /// <param name="type">更新类型 0 新增  1 去掉</param>
        /// <param name="ids">要变更的老师id</param>
        /// <param name="subjectId">学科id</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditTeacher(string type, List<long> ids,int subjectId)
        {
            string msg;
            bool isSuccess=  _teacherService.BatchUpdateSubjectId(type, ids, subjectId,out msg);
            if (isSuccess)
            {
                return Json(ApiResult.OK());
            }
            return Json(ApiResult.Error(msg));
        }
    }
}
