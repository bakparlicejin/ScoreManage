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
        protected  ISqlSugarClient _sqlSugarClient { get; set; }
        
        public BaseDal(ISqlSugarClient sqlSugarClient)
        {
            _sqlSugarClient = sqlSugarClient;
        }
        public int Add(T t)
        {
            
          return _sqlSugarClient.Insertable<T>(t).ExecuteReturnIdentity(); ;
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
        public T QueryById(int id)
        {
            return _sqlSugarClient.Queryable<T>().InSingle(id);
        }

        public bool DeleteById(int id)
        {
            return _sqlSugarClient.Deleteable<T>().In(id).ExecuteCommand()>0;
        }
        public void TransactionOperation(Action<ISqlSugarClient> action) 
        {
            try
            {
                
                _sqlSugarClient.Ado.BeginTran();
                action(this._sqlSugarClient);
                _sqlSugarClient.Ado.CommitTran();
            }
            catch (Exception ex)
            {
                _sqlSugarClient.Ado.RollbackTran();
                throw ex;
            }
        }

        public List<T> QueryByWhere(Expression<Func<T, bool>> where)
        {
            return _sqlSugarClient.Queryable<T>().Where(where).ToList();
        }
        public List<T> QueryPageData(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>>  where, Expression<Func<T, object>> orderby, OrderByType orderByType )
        {
            totalCount = 0;
            return _sqlSugarClient.Queryable<T>().Where(where).OrderBy(orderby, orderByType).ToPageList(pageIndex,pageSize,ref totalCount);

        }
    }
    
}
