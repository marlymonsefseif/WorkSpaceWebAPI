using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;
using WorkSpaceWebAPI.Services;

namespace WorkSpaceWebAPI.Repository
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly WorkSpaceDbContext _context;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _environment;

        public GalleryRepository(WorkSpaceDbContext context,IFileService fileService,IWebHostEnvironment environment)
        {
            _context = context;
            _fileService = fileService;
            _environment = environment;
        }

        public async Task<List<Gallery>> GetAllAsync()
        {
            return await _context.Galleries.ToListAsync();
        }
        public string GetFullImageUrl(string imageUrl)
        {
            return Path.Combine(_environment.ContentRootPath, imageUrl);
        }
        public async Task<List<T>> GetAllAsync<T>(Expression<Func<Gallery, T>> selector)
        {
            return await _context.Galleries.Select(selector).ToListAsync();
        }
        public async Task<List<Gallery>> GetAllBySpaceIdAsync(int spaceId)
        {
            return await _context.Galleries.Where(g=>g.SpaceId==spaceId).ToListAsync();
        }
        public async Task<List<T>> GetAllBySpaceIdAsync<T>(int spaceId, Expression<Func<Gallery, T>> selector)
        {
            return await _context.Galleries
                .Where(g => g.SpaceId == spaceId)
                .Select(selector)
                .ToListAsync();
        }

        public async Task<Gallery> GetByIdAsync(int id)
        {
            return await _context.Galleries.FindAsync(id);
        }
        public async Task<Gallery> Add(GalleryDto galleryDto)
        {
            string[] allwedExtentions = { ".jpg", ".png", ".jpeg" };
            string imageUrl= await _fileService.SaveFileAsync(galleryDto.ImgaeFile,allwedExtentions,galleryDto.SpaceId);
            Gallery gallery = new Gallery
            {
                ImageURl = imageUrl,
                Caption = galleryDto.Caption,
                SpaceId = galleryDto.SpaceId
            };
            _context.Galleries.Add(gallery);
            return gallery;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            Gallery gallery =await GetByIdAsync(id);
            if (gallery == null)
                return false;
            _fileService.DeleteFile(gallery.ImageURl);
            _context.Galleries.Remove(gallery);
            return true;
        }
        public async Task DeleteAllSpaceGalleries(int spaceId)
        {
            List<Gallery> galleries = await GetAllBySpaceIdAsync(spaceId);
            if (galleries == null || galleries.Count == 0)
                return;
            _fileService.DeleteFile(spaceId.ToString());
            _context.Galleries.RemoveRange(galleries);

        }
        public void Update(Gallery gallery)
        {
            _context.Entry(gallery).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        
    }
}
