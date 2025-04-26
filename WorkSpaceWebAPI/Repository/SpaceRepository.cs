using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WorkSpaceWebAPI.Models;
using WorkSpaceWebAPI.Repository;
namespace WorkSpaceWebAPI.Repository
{
    public class SpaceRepository : ISpaceRepository
    {
        private readonly WorkSpaceDbContext _context;

        public SpaceRepository(WorkSpaceDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Spaces> Get()
        {
            return _context.Spaces;
        }
        public IEnumerable<Spaces> Get(Expression<Func<Spaces,bool>> predicate)
        {
            return _context.Spaces.Where(predicate);
        }
        public IEnumerable<T> Get<T>(Expression<Func<Spaces, T>> selector)
        {
            return _context.Spaces.Select(selector);
        }
        public IEnumerable<T> Get<T>(Expression<Func<Spaces, bool>> predicate,Expression<Func<Spaces,T>> selector)
        {
            return _context.Spaces.Where(predicate).Select(selector);
        }
        public Spaces GetById(int id,bool isDeleted=false)
        { 
            return _context.Spaces
                   .Where(s => s.Id == id&&!isDeleted)
                   .SingleOrDefault();
        }
        public object GetById<T>(int id,Expression<Func<Spaces,T>> selector)
        {
            return _context.Spaces
                    .Where(s => s.Id == id&&!s.IsDeleted)
                    .Select(selector)
                    .SingleOrDefault();
        }
        



        public void Add(Spaces entity)
        {
            _context.Spaces.Add(entity);
        }

        public void Update(Spaces entity)
        {
            _context.Spaces.Update(entity);
        }

       
        public void Delete(Spaces entity)
        {
            _context.Spaces.Remove(entity);
        }

        

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
