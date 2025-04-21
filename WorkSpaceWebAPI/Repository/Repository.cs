using System.Collections.Generic;
using System.Linq.Expressions;

namespace WorkSpaceWebAPI.Repository
{
    public class Repository<T>
    {
        protected ProjectEntitis context;
        protected DbSet<T> dbSet;
        public Repository(ProjectEntitis context)
        {
            this.context = context;
            dbSet = context.Set<T>();

        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(Id id)
        {
            context.Remove(GetById(id));
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
        public IQueryable<T> Get(int pageNumber = 1, int size = 8)
        {
            return dbSet.Skip((pageNumber - 1) * size).Take(size);
        }
        public IQueryable<TResult> Get<TResult>(Expression<Func<T, TResult>> selector, int pageNumber = 1, int size = 8)
        {
            return dbSet.Select(selector).Skip((pageNumber - 1) * size).Take(size);
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, int pageNumber = 1, int size = 8)
        {
            return dbSet.Where(predicate).Skip((pageNumber - 1) * size).Take(size);
        }
        public IQueryable<TResult> Get<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector)
        {
            return dbSet.Where(predicate).Select(selector);
        }
        public IQueryable<TResult> Get<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, int pageNumber = 1, int size = 8)
        {
            return dbSet.Where(predicate).Select(selector).Skip((pageNumber - 1) * size).Take(size);
        }

        public T GetById(Id id)
        {
            return dbSet.Find(id);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(T updated)
        {
            dbSet.Update(updated);

        }

    }
}
