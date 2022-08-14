﻿using ScoreManager.DalInterface;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.ServiceImpl
{
    public class BaseService<T> where T : class, new()
    {
        public IBaseDal<T> _currentDal;

        public BaseService(IBaseDal<T> baseDal)
        {
            _currentDal= baseDal;
        }


        public int Add(T t)
        {
            return _currentDal.Add(t);
        }

        public List<T> Query()
        {
            return _currentDal.Query();
        }

        public bool Update(T t)
        {
            return _currentDal.Update(t);
        }

        public bool Delete(T t)
        {
            return _currentDal.Delete(t); ;
        }
        public bool DeleteById(int id)
        {
            return _currentDal.DeleteById(id);
        }
        public T QueryById(int id)
        {
            return _currentDal.QueryById(id);
        }
        public void TransactionOperation(Action<ISqlSugarClient> action)
        {
            _currentDal.TransactionOperation(action);
        }
        public List<T> QueryPageData(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, OrderByType orderByType)
        {
            totalCount = 0;
            return _currentDal.QueryPageData(pageIndex, pageSize, out totalCount, where, orderby, orderByType);

        }
    }
}
