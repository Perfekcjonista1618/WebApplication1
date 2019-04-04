using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApplication1.DAL
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetOverview(Expression<Func<T, bool>> predicate = null);
        T GetDetail(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
    }
}
