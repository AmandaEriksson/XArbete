using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace XArbete.Web.Services.Interfaces
{
    public interface IServiceBase<T> where T : class
    {
        T GetSingle(Expression<Func<T, bool>> where);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> where);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetMany(System.Func<T, bool> where);
        IEnumerable<T> GetAll();
        void Create(T entity);
        //Task CreateAsync(T entity); // Async is only viable when saving changes
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int id);
        int GetRowCount(Expression<Func<T, bool>> where);
        Task<int> GetRowCountAsync(Expression<Func<T, bool>> where);
        void Commit();
        int Count();
        Task CommitAsync();
    }
}
