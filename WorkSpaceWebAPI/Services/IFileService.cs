namespace WorkSpaceWebAPI.Services
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file, string[] AllowedExtentions, int spaceId);
        void DeleteFile(string fileName);
    }
}
