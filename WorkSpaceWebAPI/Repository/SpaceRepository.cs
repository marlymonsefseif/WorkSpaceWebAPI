using Microsoft.EntityFrameworkCore;
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

        public List<Spaces> GetAll()
        {
            return _context.Spaces
                .Include(s => s.Gallery)
                .Include(s => s.Bookings)
                .Include(s => s.SpaceAmenities)
                .ToList();
        }

        public Spaces GetById(int id)
        {
            return _context.Spaces
                .Include(s => s.Gallery)
                .Include(s => s.Bookings)
                .Include(s => s.SpaceAmenities)
                .FirstOrDefault(s => s.Id == id);
        }

        public void Insert(Spaces entity)
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

        public void DeleteById(int id)
        {
            var space = GetById(id);
            if (space != null)
                Delete(space);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
