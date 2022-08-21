using Models;
using ScoreManager.Model.Enum;
using ScoreManager.Model.ViewParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.ServiceInterface
{
    public interface ITeacherService : IBaseSerice<EDU_TEACHER>
    {
        /// <summary>
        /// 获取教师信息 携带用户信息 和 角色信息
        /// </summary>
        /// <param name="parameter">查询条件</param>
        /// <param name="totalCount">总数</param>
        /// <returns></returns>
        public List<EDU_TEACHER> GetTeacherListWithUserAndRole(TeacherListParameter parameter, ref int totalCount);
        /// <summary>
        /// 根据关键词查询数量
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        int CountByKeyWords(TeacherListParameter keyWords);
        /// <summary>
        /// 根据id获取单个老师的全部信息  包括学科 角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EDU_TEACHER GetFullInfoById(int id);
        /// <summary>
        /// 更新老师的用户密码，老师相关信息，角色相关信息
        /// </summary>
        /// <param name="teacher"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool UpdateFullInfo(EDU_TEACHER teacher, out string msg);
        /// <summary>
        /// 删除老师的一切信息 包括用户信息 角色信息 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool DeleteFullInfo(int id, out string msg);
        /// <summary>
        /// 批量更新老师的学科信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="ids"></param>
        /// <param name="subjectId"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool BatchUpdateSubjectId(string type, List<long> ids, int subjectId, out string msg);
    }
}
