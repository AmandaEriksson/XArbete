using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XArbete.Web.Data;
using XArbete.Web.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Web.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        protected readonly XArbeteContext Context;
        protected readonly DbSet<T> DbSet;

        public ServiceBase(XArbeteContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }
        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public virtual void Create(T entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet;
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetMany(System.Func<T, bool> where)
        {
            return DbSet.Where(where);
        }

        public int GetRowCount(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetRowCountAsync(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public T GetSingle(Expression<Func<T, bool>> where)
        {
            return DbSet.SingleOrDefault(where);
        }

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    
    }
}
