using Models;
using ScoreManager.Model.ViewParameters;
using ScoreManager.ServiceInterface;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.ServiceImpl
{
    public class TeacherService : BaseService<EDU_TEACHER>, ITeacherService
    {
        public TeacherService(ISqlSugarClient sqlSugarClient) : base(sqlSugarClient)
        {
        }

        /// <summary>
        /// 获取教师信息 携带用户信息 和 角色信息
        /// </summary>
        /// <param name="parameter">查询条件</param>
        /// <param name="totalCount">总数</param>
        /// <returns></returns>
        public List<EDU_TEACHER> GetTeacherListWithUserAndRole(TeacherListParameter parameter,ref int totalCount)
        {

           return _sqlSugarClient.Queryable<EDU_TEACHER>()
                .Includes(x => x.User)
                .Includes(x => x.Roles)
                .Where(x=>x.User.USERNAME.Contains(parameter.KeyWords)||x.NAME.Contains(parameter.KeyWords))
                .ToPageList(parameter.PageIndex,parameter.PageSize,ref totalCount);

        }

        /// <summary>
        /// 根据关键词查询数量
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public int CountByKeyWords(TeacherListParameter parameter)
        {
            return _sqlSugarClient.Queryable<EDU_TEACHER>()
                .Includes(x => x.User)
                .Includes(x => x.Roles)
                .Where(x => x.User.USERNAME.Contains(parameter.KeyWords) || x.NAME.Contains(parameter.KeyWords)).Count();
        }
    }
}
