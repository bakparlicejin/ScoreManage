using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.DalImpl
{
    public class BaseDal<T> where T : class ,new()
    {
        private  ISqlSugarClient _sqlSugarClient { get; set; }
        
        public BaseDal(ISqlSugarClient sqlSugarClient)
        {
            _sqlSugarClient = sqlSugarClient;
        }
        public bool Add(T t)
        {
          return  _sqlSugarClient.Insertable<T>(t).ExecuteCommand() > 0;
        }

        public List<T> Query()
        {
            return _sqlSugarClient.Queryable<T>().ToList();
        }

        public bool Update(T t)
        {
            return _sqlSugarClient.Updateable<T>(t).ExecuteCommand() > 0;
        }

        public bool Delete(T t)
        {
            return _sqlSugarClient.Deleteable<T>(t).ExecuteCommand() > 0;
        }

        public List<T> QueryPageData(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>>  where, Expression<Func<T, object>> orderby, OrderByType orderByType )
        {
            totalCount = 0;
            return _sqlSugarClient.Queryable<T>().Where(where).OrderBy(orderby, orderByType).ToPageList(pageIndex,pageSize,ref totalCount);

        }
    }
    
}
