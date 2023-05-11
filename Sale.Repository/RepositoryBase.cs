using Microsoft.EntityFrameworkCore;
using Sale.Contracts;
using Sale.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {   
        protected SaleContext RepositoryContext { get; set; }
        public RepositoryBase(SaleContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<T> GetAll()
        {
            return RepositoryContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression);
        }
        public T FindById(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().SingleOrDefault(expression);
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }
        public void Save()
        {
            RepositoryContext.SaveChanges();
        }

        
    }
}
