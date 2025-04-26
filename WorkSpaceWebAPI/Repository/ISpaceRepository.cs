using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public interface ISpaceRepository
    {
        public IEnumerable<Spaces> Get();
        public IEnumerable<Spaces> Get(Expression<Func<Spaces, bool>> predicate);
        public IEnumerable<T> Get<T>(Expression<Func<Spaces, T>> selector);
        public IEnumerable<T> Get<T>(Expression<Func<Spaces, bool>> predicate, Expression<Func<Spaces, T>> selector);
        public Spaces GetById(int id, bool isDeleted = false);
        public object GetById<T>(int id, Expression<Func<Spaces, T>> selector);
        public void Add(Spaces entity);
        public void Update(Spaces entity);
        public void Delete(Spaces entity);
        public void SaveChanges();
    }
}
