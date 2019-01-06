using Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Contracts
{

    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        IEnumerable<T> Find(Expression<Func<T,bool>>predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);

        
    }
}
