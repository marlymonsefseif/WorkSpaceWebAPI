namespace WorkSpaceWebAPI.Services
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file, string[] AllowedExtentions, string spaceName);
        void DeleteFile(string fileName, string spaceName);
    }
}
