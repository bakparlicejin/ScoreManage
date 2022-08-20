using Models;
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
    }
}
