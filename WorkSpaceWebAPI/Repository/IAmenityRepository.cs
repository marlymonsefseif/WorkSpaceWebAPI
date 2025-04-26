using Microsoft.EntityFrameworkCore;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public interface IAmenityRepository
    {
        public Task<List<Amenity>> GetAllAsync();

        public Task<Amenity> GetByIdAsync(int id);

        public void Add(Amenity amenity);

        public Task<bool> DeleteAsync(int id);
        public void SaveChanges();
        
    }
}
