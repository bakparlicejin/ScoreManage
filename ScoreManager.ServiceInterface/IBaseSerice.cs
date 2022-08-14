using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.ServiceInterface
{
    public interface IBaseSerice<T> where T : class, new()
    {
        public int Add(T t);

        public List<T> Query();

        public bool Update(T t);

        public bool Delete(T t);
        public T QueryById(int id);
        public bool DeleteById(int id);
        public void TransactionOperation(Action<ISqlSugarClient> action);

        public List<T> QueryPageData(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, OrderByType orderByType);
    }
}
