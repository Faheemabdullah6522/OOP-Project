using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Window_Forms.Repositories
{
    /// <summary>
    /// Generic repository interface
    /// Demonstrates abstraction principle
    /// </summary>
    public interface IRepository<T> where T : class
    {
        // CRUD Operations
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
