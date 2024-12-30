namespace FlowerProjectP323.Areas.Admin.Helpers
{
    public class FileService : IFileService
    {
        public async Task<string> UploadAsync(IFormFile file, string webRootPath)
        {
            var fileName = $"{Guid.NewGuid()}.{file.FileName}";
            var path = Path.Combine(webRootPath, "assets/img", fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }

        public void Delete(string webRootPath, string fileName)
        {
            var path = Path.Combine(webRootPath, "assets", "img", fileName);

            if (File.Exists(path))
                File.Delete(path);
        }

        public bool IsImage(IFormFile file)
        {
            if (file.ContentType.Contains("image/"))
            {
                return true;
            }
            return false;
        }
        public bool CheckSize(IFormFile file, int size)
        {
            if (file.Length / 1024 > size)
            {
                return false;
            }
            return true;
        }
    }
}