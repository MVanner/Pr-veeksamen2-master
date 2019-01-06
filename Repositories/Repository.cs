using Contracts;
using Entities;
using Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repositories
{
    class Repository<T> : IRepository<T> where T : class
    {
        private readonly GiftDbContext _db;

        public Repository(GiftDbContext db)
        {
            _db = db;
        }

        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _db.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate);
        }

        public T Get(Guid id)
        {
            return _db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
        }
    }
}
