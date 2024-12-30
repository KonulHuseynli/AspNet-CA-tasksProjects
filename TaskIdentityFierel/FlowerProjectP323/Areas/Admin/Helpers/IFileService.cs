namespace FlowerProjectP323.Areas.Admin.Helpers
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file, string webRootPath);

        void Delete(string webRootPath, string fileName);
        bool IsImage(IFormFile file);
        bool CheckSize(IFormFile file, int size);

    }
}
