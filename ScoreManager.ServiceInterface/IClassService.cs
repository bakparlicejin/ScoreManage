using Models;
using ScoreManager.Model.ViewParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.ServiceInterface
{
    public interface IClassService : IBaseSerice<EDU_CLASS>
    {
        /// <summary>
        /// 获取班级信息 携带班级老师信息
        /// </summary>
        /// <returns></returns>
        List<EDU_CLASS> GetAllClassInfo();
        /// <summary>
        /// 添加班级信息
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool AddClass(AddClassParameter parameter, out string msg);
        /// <summary>
        /// 根据班级id 获取班级信息 携带班级老师信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EDU_CLASS GetAllClassInfoByClassId(int id);
        /// <summary>
        /// 修改班级信息 修改班级老师信息
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool UpdateTeacher(UpdateClassParameter parameter, out string msg);
    }
}
