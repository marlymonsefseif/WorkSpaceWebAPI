using Microsoft.EntityFrameworkCore;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public class AmenityRepsitory : IAmenityRepository
    {
        private readonly WorkSpaceDbContext _context;
        public AmenityRepsitory(WorkSpaceDbContext context)
        {
            _context = context;
        }
        public async Task<List<Amenity>> GetAllAsync()
        {
            return await _context.Amenities.ToListAsync();
        }
        public async Task<Amenity> GetByIdAsync(int id)
        {
            return await _context.Amenities.FindAsync(id);
        }
        public void Add(Amenity amenity)
        {
            _context.Amenities.Add(amenity);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            Amenity amenity = await GetByIdAsync(id);
            if (amenity == null) 
                return false;
            _context.Amenities.Remove(amenity);
            return true;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
