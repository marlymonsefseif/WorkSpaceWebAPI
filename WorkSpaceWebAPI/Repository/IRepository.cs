using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WorkSpaceWebAPI.Repository
{
    public interface IRepository<T> where T : class
    {
        public void Add(T entity);


        public void Delete(int id);


        public IQueryable<T> Get();

        public IQueryable<T> Get(int pageNumber = 1, int size = 8);

        public IQueryable<TResult> Get<TResult>(Expression<Func<T, TResult>> selector, int pageNumber = 1, int size = 8);

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate);

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, int pageNumber = 1, int size = 8);

        public IQueryable<TResult> Get<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector);

        public IQueryable<TResult> Get<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, int pageNumber = 1, int size = 8);
        public T GetById(int id);
        public int Save();
        public void Update(T updated);
      
    }
}
