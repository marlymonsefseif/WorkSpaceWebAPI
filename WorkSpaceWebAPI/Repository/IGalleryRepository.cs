using System.Linq.Expressions;
using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public interface IGalleryRepository
    {
        Task<List<Gallery>> GetAllAsync();
        Task<List<Gallery>> GetAllBySpaceIdAsync(int spaceId);
        Task<List<T>> GetAllBySpaceIdAsync<T>(int spaceId, Expression<Func<Gallery, T>> selector);
        Task<List<T>> GetAllAsync<T>(Expression<Func<Gallery, T>> selector);
        Task<Gallery> GetByIdAsync(int id);
        string GetFullImageUrl(string imageUrl);
        Task<Gallery> Add(GalleryDto galleryDto);
        Task<bool> DeleteAsync(int id);
        Task DeleteAllSpaceGalleries(int spaceId);
        void Update(Gallery gallery);
        void SaveChanges();
    }
}
