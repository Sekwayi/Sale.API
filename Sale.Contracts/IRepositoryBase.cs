﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Contracts
{
    public interface IRepositoryBase<T>
    {   
        IEnumerable<T> GetAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T FindById(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
