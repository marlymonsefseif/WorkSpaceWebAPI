namespace WorkSpaceWebAPI.Services
{
    public class FileService:IFileService
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> SaveFileAsync(IFormFile imageFile, string[] AllowedExtentions, string spaceName)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentNullException(nameof(imageFile), "File cannot be null or empty");
            }
            if (imageFile.Length>1*1000*1000)
            {
                throw new ArgumentException("File size exceeds the limit of 1MB", nameof(imageFile));
            }
            string extension = Path.GetExtension(imageFile.FileName);
            if (!AllowedExtentions.Contains(extension))
            {
                throw new ArgumentException($"File type {extension} is not allowed only {string.Join(',', AllowedExtentions)}", nameof(imageFile));
            }
            string fileName = Guid.NewGuid().ToString() + extension;
            string path = Path.Combine(webHostEnvironment.ContentRootPath, "GalleryUploads");
            path = Path.Combine(path, spaceName);
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            await imageFile.CopyToAsync(fileStream);
            return fileName;


        }
        public void DeleteFile(string fileName, string spaceName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName), "File path cannot be null or empty");
            }
            string path = Path.Combine(webHostEnvironment.ContentRootPath, "GalleryUploads");
            path = Path.Combine(path, spaceName);
            path = Path.Combine(path, fileName);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"File {fileName} not found in {path}");
            }
            File.Delete(path);
        }

    }
}
