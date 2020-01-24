using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XArbete.Web.Data;
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

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();

        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public virtual void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void DeleteById(int id)
        {
            var entity = DbSet.Find(id);
            if (entity != null) 
                DbSet.Remove(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet;
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
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

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> where)
        {
            return await DbSet.SingleOrDefaultAsync(where);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

    }
}
