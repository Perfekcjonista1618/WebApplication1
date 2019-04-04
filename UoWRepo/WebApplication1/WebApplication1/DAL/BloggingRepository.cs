using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApplication1.DAL
{
    public class BloggingRepository<T> : IRepository<T> where T : class
    {
        
        private BloggingContext _db = null;
        // obiekt reprezentuje kolekcję wszystkich encji w danym kontekście
        // lub może być wynikiem zapytania z bazy danych
        DbSet<T> _objectSet;
        public BloggingRepository(BloggingContext db)
        {
            _db = db;
            _objectSet = db.Set<T>();
        }
        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }
        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
        }
        public T GetDetail(Expression<Func<T, bool>> predicate)
        {
            return _objectSet.First(predicate);
        }
        public IEnumerable<T> GetOverview(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
                return _objectSet.Where(predicate);
            return _objectSet.AsEnumerable();
        }
    }
}
