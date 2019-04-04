using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DAL
{
    public class UoW : IDisposable
    {
        private BloggingContext _db = null;
        public UoW(BloggingContext db)
        {
            _db = db;
        }
        // Słownik będzie używany do sprawdzania instancji repozytoriów
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public IRepository<T> Repository<T>() where T : class
        {
            // Jeżeli instancja danego repozytorium istnieje - zostanie zwrócona
            if (repositories.Keys.Contains(typeof(T)) == true)
                return repositories[typeof(T)] as IRepository<T>;
            // Jeżeli nie, zostanie utworzona nowa i dodana do słownika
            IRepository<T> repo = new BloggingRepository<T>(_db);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    _db.Dispose();
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
